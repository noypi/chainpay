using ChainPay.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ChainPay.Test
{
    [TestClass]
    public class SerializeTests
    {
        [TestMethod]
        public void TestSignatureRequest()
        {
            var expectedModel = new SignatureRequest()
            {
                BlockchainCode = "IOST",
                BlockchainName = "Internet Of Services",
                HashAlgo = "SHA3-256",
                MessageHash = "some hash"
            };

            string sr = ChainPay.CreateSignatureRequest(expectedModel);
            var resultModel = ChainPay.ReadSignatureRequest(sr);

            Assert.AreEqual(expectedModel.BlockchainName, resultModel.BlockchainName);
            Assert.AreEqual(expectedModel.BlockchainCode, resultModel.BlockchainCode);
            Assert.AreEqual(expectedModel.HashAlgo, resultModel.HashAlgo);
            Assert.AreEqual(expectedModel.MessageHash, resultModel.MessageHash);
        }
    }
}
