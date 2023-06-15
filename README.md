# NHodlHodl

A C# library to use the HodlHodl, a no KYC p2p Bitcoin trading platform.

## usage
* Install NHodlHodl
* Instantiate an instance of `HodlHodlClient`, using your API key 
* Call the endpoints as needed. You can find a detailed description of each endpoint at https://hodlhodl.com/api/docs
* Some endpoints require a `signed request`, as described at https://hodlhodl.com/api/docs#signed-request. This is achievable by getting the signature key from your account and calling the following code:
```csharp
    var (nonce, hash) = HodlHodlClient.GenerateSigningHash("api key here", "signature key here");
```
* The seed that contains your hodlhodl private keys is encrypted with a password.
```csharp
    //decrypt the master key
    var masterKey = HodlHodlClient.DecryptSeed(encryptedSeed, paymentPassword, out var decryptedSeed);
    //derive a key used for a specific contract
    var key = masterKey.Derive(derivationIndex).PrivateKey;
``` 
* You can verify the multsig address used in a contract is correct with the following code:
```csharp
    var (address, redeem) = HodlHodlClient.GenerateEscrowAddress(server, seller, buyer, Network.TestNet);
```