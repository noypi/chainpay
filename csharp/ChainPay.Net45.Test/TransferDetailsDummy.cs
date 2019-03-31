using System;
using System.Collections.Generic;
using System.Text;

namespace ChainPay.Net45.Test
{
    public class TransferDetailsDummy
    {
        public int ChainId { get; set; }
        public long GasLimit { get; set; }
        public List<string> Actions { get; set; } = new List<string>();
    }
}
