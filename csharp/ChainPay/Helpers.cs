namespace ChainPay
{
    using System;

    public partial class ChainPay
    {
        public static readonly DateTime EpochUTC = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);
        /// <summary>
        /// millis = todate - epoch
        /// </summary>
        /// <param name="todate"></param>
        /// <returns></returns>
        public static long MillisFromEpoch(DateTime todate)
        {
            return (long)(todate - EpochUTC).TotalMilliseconds;
        }

        public static DateTime ExpiryMillisToDate(string expirymillis)
        {
            var timespan = new TimeSpan(MillisToTicks(long.Parse(expirymillis)));
            return EpochUTC.Add(timespan);
        }

        public static long MillisToTicks(long millis) => TimeSpan.TicksPerMillisecond * millis;
    }
}
