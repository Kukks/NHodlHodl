using NBitcoin;
using NBitcoin.DataEncoders;

namespace NHodlHodl.Tests;

public class UnitTest1
{
    [Fact]
    public void CanDecryptSeed()
    {
        var encryptedSeed =
            "ES1:7eda9c6f743602a3175d4c522381ab8fb402a75e57cdb3af38aaa0511eac09f28ac45e6f3c368962453de190081f94311fbeab69406e8a36241f0f79bb5d81ee881c73eea3cc488f501cf0030355374f1bba0c16071a773e9e7c1879:8a4acbac1c107faf5652782d5b569a7e:pbkdf2:10000";
        var paymentPassword = "gg5GvNZAwgWQeVS";
        var aesKey = "de9bccdb2a8d14136967bc3286f0ce6a";
        var expected =
            "646131227d65c6d729bc82ddc9e4d141ab69b1ee0dc840cf07183fc8b6f7faeb9ba2d9f0ad357102c578a74700c4491349cd4002991a1c4e8d41accc538d27cc";
        var xpub =
            "xpub661MyMwAqRbcFRUMeZHWy6W9D7MkVbboYehf3RrDPdGFxqfHD3uWBJfMFrrMjTNEddTgYSFktearKrCnoAZV949SSNpakwMGPDeu98DZFiU";
        uint derivationIndex = 10164;
        var expectedDerivedPrivateKey = "4aca31a8e38da930d260253b8c02191abf4bf40bce355712522ac369229b7ea5";

        var generatedSeed = HodlHodlClient.DecryptSeed(encryptedSeed, paymentPassword, out var decryptedSeed);
        Assert.Equal(expected, Encoders.Hex.EncodeData(decryptedSeed));
        Assert.Equal(ExtPubKey.Parse(xpub, Network.Main).Derive(derivationIndex).PubKey.WitHash.ToString(),
            generatedSeed.Derive(derivationIndex).PrivateKey.PubKey.WitHash.ToString());
    }

    [Fact]
    public void ContractTest()
    {
        var server = new PubKey("0245404be5e05aa79ddac54b6bd9d0199f29fe268c5b35b835e6d370fd8c90f1b6");
        var seller = new PubKey("031eb5fa26f276b9fe6f699ff653fd2182fcf6f5f564b65e502e532f8b9e3eab7e");
        var buyer = new PubKey("0380c2f9b72112291a92875bcdfef399675c5d81c08532e3b88831a44711e6c37f");

        var (address, redeem) = HodlHodlClient.GenerateEscrowAddress(server, seller, buyer, Network.TestNet);
        Assert.Equal(
            "2 0245404be5e05aa79ddac54b6bd9d0199f29fe268c5b35b835e6d370fd8c90f1b6 031eb5fa26f276b9fe6f699ff653fd2182fcf6f5f564b65e502e532f8b9e3eab7e 0380c2f9b72112291a92875bcdfef399675c5d81c08532e3b88831a44711e6c37f 3 OP_CHECKMULTISIG",
            redeem.ToString());
        var expected = BitcoinAddress.Create("2Myb7A6rvG2t5zZt5mb1Gpk7khxb94NqCbg", Network.TestNet);
        Assert.Equal(expected, address);
    }
}