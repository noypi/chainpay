namespace ChainPay.Models
{
    using Newtonsoft.Json;

    public class SignatureResponse
    {
        [JsonProperty("ChainName")]
        public string BlockchainName { get; set; }

        [JsonProperty("ChainCode")]
        public string BlockchainCode { get; set; }

        [JsonProperty("Tag")]
        public string Tag { get; set; }
        
        [JsonProperty("MessageHash")]
        public string MessageHash { get; set; }

        [JsonProperty("Signature")]
        public string Signature { get; set; }

        /// <summary>
        /// Can be any of
        ///   - Disapprove
        ///   - DidTransfer
        /// </summary>
        [JsonProperty("Result")]
        public string Result { get; set; }

        /// <summary>
        /// Must be filled if Result==DidTransfer
        /// </summary>
        [JsonProperty("TransactionHash")]
        public string TransactionHash { get; set; }
    }
}
