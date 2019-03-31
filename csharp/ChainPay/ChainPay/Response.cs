namespace ChainPay
{
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
        public static string CreateSignatureResponse(Models.SignatureResponse res)
        {
            return Common.CreateSignature<Models.SignatureResponse>(res, "Response");
        }

        /// <summary>
        /// Reads a signature request
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="sr"></param>
        /// <returns></returns>
        public static Models.SignatureResponse ReadSignatureResponse(string sr)
        {
            using (var mem = new MemoryStream(UnicodeEncoding.ASCII.GetBytes(sr)))
            using (var reader = new StreamReader(mem))
            {
                return ReadSignatureResponse(reader);
            }
        }

        /// <summary>
        /// Reads the Signature Request
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="reader"></param>
        /// <returns></returns>
        public static Models.SignatureResponse ReadSignatureResponse(StreamReader reader)
        {
            return Common.ReadSignature<Models.SignatureResponse>(reader);
        }
    }
}
