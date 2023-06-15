using System.Collections;
using System.Net.Http.Headers;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;
using NBitcoin;
using NBitcoin.Crypto;
using NBitcoin.DataEncoders;
using Newtonsoft.Json;
using NHodlHodl.Models;

namespace NHodlHodl;

public partial class HodlHodlClient
{
    private readonly Uri _backendUri = new("https://hodlhodl.com/api");
    private readonly string _apiKey;
    private readonly HttpClient _httpClient;

    public HodlHodlClient(string apiKey, HttpClient? httpClient = null, Uri? backendUri = null)
    {
        _apiKey = apiKey;
        _httpClient = httpClient ?? new HttpClient();
        _backendUri = backendUri ?? _backendUri;
    }

    public static (string nonce, string hash) GenerateSigningHash(string apiKey, byte[] signatureKey, out string nonce)
    {
        nonce = DateTimeOffset.UtcNow.ToUnixTimeSeconds().ToString();
        var msg = $"{apiKey}:{nonce}";
        return (nonce, Encoders.Hex.EncodeData(Hashes.HMACSHA256(signatureKey, Encoding.UTF8.GetBytes(msg))));
    }

    public static (byte[] cipher, byte[] salt, int iterations) ParseEncryptedSeed(string encryptedSeed)
    {
        if (!Regex.IsMatch(encryptedSeed, "^ES1:([a-f0-9]+):([a-f0-9]+):pbkdf2:[0-9]+"))
        {
            throw new FormatException("The provided encrypted seed was in an invalid format");
        }

        //ES1:<ciphertext_hex>:<salt_hex>:pbkdf2:10000
        var parts = encryptedSeed.Split(":");
        return (Encoders.Hex.DecodeData(parts[1]), Encoders.Hex.DecodeData(parts[2]), Convert.ToInt32(parts[4]));
    }

    static byte[] Decrypt(byte[] cipherBytes, byte[] encKey, byte[] authTag, byte[] nonce)
    {
        var plainBytes = new byte[cipherBytes.Length];
        using var aesGcm = new AesGcm(encKey);
        aesGcm.Decrypt(nonce, cipherBytes, authTag, plainBytes);
        return plainBytes;
    }

    public static ExtKey DecryptSeed(string encryptedSeed, string paymentPassword, out byte[] seed)
    {
        var password = Encoding.UTF8.GetBytes(paymentPassword);
        byte[] encKey;

        var (cipher, salt, iterations) = ParseEncryptedSeed(encryptedSeed);
        using (var deriveBytes = new Rfc2898DeriveBytes(password, salt, iterations, HashAlgorithmName.SHA256))
        {
            encKey = deriveBytes.GetBytes(16);
        }

        var iv = cipher.Take(12).ToArray();
        var content = cipher.Skip(12).Take(cipher.Length - 16 - 12).ToArray();
        var authTag = cipher.TakeLast(16).ToArray();
        seed = Decrypt(content, encKey, authTag, iv);
        var mac = Hashes.HMACSHA256(password, seed).Take(16);
        if (!mac.SequenceEqual(salt))
        {
            throw new ArgumentException("The key is invalid", nameof(paymentPassword));
        }

        return ExtKey.CreateFromSeed(seed);
    }

    public static (BitcoinAddress address, Script redeem) GenerateEscrowAddress(PubKey service, PubKey seller,
        PubKey buyer, Network network)
    {
        var script = PayToMultiSigTemplate.Instance.GenerateScriptPubKey(2, new[] {service, seller, buyer});
        var p2wshScript = script.WitHash.ScriptPubKey;
        var p2shScript = p2wshScript.Hash.ScriptPubKey;
        return (p2shScript.GetDestinationAddress(network)!, script);
    }


    protected async Task HandleResponse(HttpResponseMessage message)
    {
        if (!message.IsSuccessStatusCode &&
            message.Content?.Headers?.ContentType?.MediaType?.StartsWith("application/json",
                StringComparison.OrdinalIgnoreCase) is true)
        {
            throw new HodlHodlException
            {
                Error = JsonConvert.DeserializeObject<HodlHodlError>(await message.Content.ReadAsStringAsync())
            };
        }

        message.EnsureSuccessStatusCode();
    }

    protected async Task<T> HandleResponse<T>(HttpResponseMessage message)
    {
        await HandleResponse(message);
        var str = await message.Content.ReadAsStringAsync();
        return JsonConvert.DeserializeObject<T>(str);
    }

    public async Task<T> SendHttpRequest<T>(string path,
        Dictionary<string, object>? queryPayload = null,
        HttpMethod? method = null, CancellationToken cancellationToken = default)
    {
        using var resp = await _httpClient.SendAsync(CreateHttpRequest(path, queryPayload, method), cancellationToken);
        return await HandleResponse<T>(resp);
    }

    public async Task<T> SendHttpRequest<T>(string path,
        object bodyPayload = null,
        HttpMethod? method = null, CancellationToken cancellationToken = default)
    {
        using var resp =
            await _httpClient.SendAsync(CreateHttpRequest(path: path, bodyPayload: bodyPayload, method: method),
                cancellationToken);
        return await HandleResponse<T>(resp);
    }
    
    public async Task SendHttpRequest(string path,
        object bodyPayload = null,
        HttpMethod? method = null, CancellationToken cancellationToken = default)
    {
        using var resp =
            await _httpClient.SendAsync(CreateHttpRequest(path: path, bodyPayload: bodyPayload, method: method),
                cancellationToken);
        await HandleResponse(resp);
    }

    protected virtual HttpRequestMessage CreateHttpRequest(string path,
        Dictionary<string, object>? queryPayload = null,
        HttpMethod? method = null)
    {
        UriBuilder uriBuilder = new UriBuilder(_backendUri) {Path = path};
        if (queryPayload != null && queryPayload.Any())
        {
            AppendPayloadToQuery(uriBuilder, queryPayload);
        }

        var httpRequest = new HttpRequestMessage(method ?? HttpMethod.Get, uriBuilder.Uri);
        httpRequest.Headers.Authorization = new AuthenticationHeaderValue("Bearer", _apiKey);


        return httpRequest;
    }

    protected virtual HttpRequestMessage CreateHttpRequest<T>(string path,
        Dictionary<string, object>? queryPayload = null,
        T bodyPayload = default, HttpMethod? method = null)
    {
        var request = CreateHttpRequest(path, queryPayload, method);
        if (typeof(T).IsPrimitive || !EqualityComparer<T>.Default.Equals(bodyPayload, default(T)))
        {
            request.Content = new StringContent(JsonConvert.SerializeObject(bodyPayload), Encoding.UTF8,
                "application/json");
        }

        return request;
    }

    public static void AppendPayloadToQuery(UriBuilder uri, KeyValuePair<string, object> keyValuePair)
    {
        if (uri.Query.Length > 1)
            uri.Query += "&";

        UriBuilder uriBuilder = uri;
        if (!(keyValuePair.Value is string) &&
            keyValuePair.Value.GetType().GetInterfaces().Contains((typeof(IEnumerable))))
        {
            foreach (var item in (IEnumerable) keyValuePair.Value)
            {
                uriBuilder.Query = uriBuilder.Query + Uri.EscapeDataString(keyValuePair.Key) + "=" +
                                   Uri.EscapeDataString(item.ToString()) + "&";
            }
        }
        else
        {
            uriBuilder.Query = uriBuilder.Query + Uri.EscapeDataString(keyValuePair.Key) + "=" +
                               Uri.EscapeDataString(keyValuePair.Value.ToString()) + "&";
        }

        uri.Query = uri.Query.Trim('&');
    }

    public static void AppendPayloadToQuery(UriBuilder uri, Dictionary<string, object>? payload)
    {
        if (uri.Query.Length > 1)
            uri.Query += "&";
        foreach (KeyValuePair<string, object> keyValuePair in payload)
        {
            AppendPayloadToQuery(uri, keyValuePair);
        }
    }
}