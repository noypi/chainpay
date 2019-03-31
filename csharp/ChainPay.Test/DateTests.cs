namespace ChainPay.Test
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using System;

    [TestClass]
    public class DateTests
    {
        [TestMethod]
        public void TestExpiryMillis()
        {
            var date = new DateTime(2019, 01, 01, 0, 0, 0, DateTimeKind.Utc);

            var expiryMillis = ChainPay.MillisFromEpoch(date).ToString();
            var resultDate = ChainPay.ExpiryMillisToDate(expiryMillis);

            Assert.AreEqual(date, resultDate);
        }
    }
}
