namespace ChainPay
{
    using global::ChainPay.Models;
    using System.IO;
    using System.Text;

    public partial class ChainPay
    {

        /// <summary>
        /// Creates a Signature Request
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="req"></param>
        /// <returns></returns>
        public static string CreateSignatureRequest(SignatureRequest req)
        {
            return Common.CreateSignature(req, "Request");
        }

        /// <summary>
        /// Reads a signature request
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="sr"></param>
        /// <returns></returns>
        public static Models.SignatureRequest ReadSignatureRequest(string sr)
        {
            using (var mem = new MemoryStream(UnicodeEncoding.ASCII.GetBytes(sr)))
            using (var reader = new StreamReader(mem))
            {
                return ReadSignatureRequest(reader);
            }
        }

        /// <summary>
        /// Reads the Signature Request
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="reader"></param>
        /// <returns></returns>
        public static Models.SignatureRequest ReadSignatureRequest(StreamReader reader)
        {
            return Common.ReadSignature(SignatureRequest.Parser, reader) as SignatureRequest;
        }
    }
}
