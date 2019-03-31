namespace ChainPay.Models
{
    using Newtonsoft.Json;

    public class SignatureResponse
    {
        /// <summary>
        /// The current transaction is cancelled
        /// </summary>
        public static readonly string RESULT_DISAPPROVE = "Disapprove";

        /// <summary>
        /// Client have executed the transaction
        ///   - the signature is empty
        ///   - the transaction hash must be filled
        /// </summary>
        public static readonly string RESULT_DIDTRANSFER = "DidTransfer";

        /// <summary>
        /// Client have approve the request
        ///    - the signature must be filled
        /// </summary>
        public static readonly string RESULT_APPROVE = "Approve";
        
        [JsonProperty("ChainName")]
        public string BlockchainName { get; set; }

        [JsonProperty("ChainCode")]
        public string BlockchainCode { get; set; }

        /// <summary>
        /// Must send the same Tag from the request
        /// </summary>
        [JsonProperty("Tag")]
        public string Tag { get; set; }
        
        /// <summary>
        /// Base64 encode signature
        /// </summary>
        [JsonProperty("Signature")]
        public string Signature { get; set; }

        /// <summary>
        /// Can be any of
        ///   - Disapprove
        ///   - DidTransfer
        ///   - Approve
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
