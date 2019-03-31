namespace ChainPay.Models
{
    using Newtonsoft.Json;

    public class SignatureRequest<T>
    {
        [JsonProperty("ChainName")]
        public string BlockchainName { get; set; }

        [JsonProperty("ChainCode")]
        public string BlockchainCode { get; set; }

        [JsonProperty("Tag")]
        public string Tag { get; set; }

        /// <summary>
        /// Can be any of:
        ///    - MustReply
        ///    - ClientCanTransfer
        /// </summary>
        [JsonProperty("TransferMethod")]
        public string TransferMethod { get; set; }

        [JsonProperty("MessageHash")]
        public string MessageHash { get; set; }

        [JsonProperty("HashAlgo")]
        public string HashAlgo { get; set; }

        /// <summary>
        /// contains required parameters to validate the message
        /// </summary>
        [JsonProperty("TransferDetails")]
        public T TransferDetails { get; set; }
    }
}
