using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ChainPay.Test
{
    [TestClass]
    public class SerializeTests
    {
        [TestMethod]
        public void TestSignatureRequest()
        {
            var expectedDetails = new TransferDetailsDummy()
            {
                ChainId = 1234,
                GasLimit = 100000
            };
            var expectedModel = new Models.SignatureRequest<TransferDetailsDummy>()
            {
                BlockchainCode = "IOST",
                BlockchainName = "Internet Of Services",
                HashAlgo = "SHA3-256",
                MessageHash = "some hash",
                TransferDetails = expectedDetails
            };

            expectedDetails.Actions.Add("transfer");
            expectedDetails.Actions.Add("createaccount");

            string sr = ChainPay.CreateSignatureRequest<TransferDetailsDummy>(expectedModel);
            var resultModel = ChainPay.ReadSignatureRequest<TransferDetailsDummy>(sr);

            Assert.AreEqual(expectedModel.BlockchainName, resultModel.BlockchainName);
            Assert.AreEqual(expectedModel.BlockchainCode, resultModel.BlockchainCode);
            Assert.AreEqual(expectedModel.HashAlgo, resultModel.HashAlgo);
            Assert.AreEqual(expectedModel.MessageHash, resultModel.MessageHash);

            var expected = expectedModel.TransferDetails;
            var result = resultModel.TransferDetails;
            Assert.AreEqual(expected.ChainId, result.ChainId);
            Assert.AreEqual(expected.GasLimit, result.GasLimit);
            CollectionAssert.AreEqual(expected.Actions, result.Actions);
        }
    }
}
