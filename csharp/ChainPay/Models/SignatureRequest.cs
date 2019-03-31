namespace ChainPay.Models
{
    using Newtonsoft.Json;

    public class SignatureRequest<T>
    {
        /// <summary>
        /// Client is expected to response
        /// </summary>
        public static readonly string TRANSFERMETHOD_MUSTREPLY = "MustReply";

        /// <summary>
        /// Client can send the transfer directly, and may not response
        /// </summary>
        public static readonly string TRANSFERMETHOD_CLIENTCANTRANSFER = "ClientCanTransfer";

        [JsonProperty("ChainName")]
        public string BlockchainName { get; set; }

        [JsonProperty("ChainCode")]
        public string BlockchainCode { get; set; }

        [JsonProperty("ExpiryUTCMillis")]
        public string ExpiryUTCMillis { get; set; }

        /// <summary>
        /// Any string, this should be sent back by the client
        /// </summary>
        [JsonProperty("Tag")]
        public string Tag { get; set; }

        /// <summary>
        /// Can be any of:
        ///    - MustReply
        ///    - ClientCanTransfer
        /// </summary>
        [JsonProperty("TransferMethod")]
        public string TransferMethod { get; set; }

        /// <summary>
        /// Base64 of the expected message hash
        /// </summary>
        [JsonProperty("MessageHash")]
        public string MessageHash { get; set; }

        /// <summary>
        /// The hash algo used in MessageHash
        /// Example: SHA3-256
        /// </summary>
        [JsonProperty("HashAlgo")]
        public string HashAlgo { get; set; }

        /// <summary>
        /// contains required parameters to validate the message
        /// </summary>
        [JsonProperty("TransferDetails")]
        public T TransferDetails { get; set; }
    }
}
