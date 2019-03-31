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
        public static string CreateSignatureRequest<T>(Models.SignatureRequest<T> req)
        {
            return Common.CreateSignature<Models.SignatureRequest<T>>(req, "Request");
        }

        /// <summary>
        /// Reads a signature request
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="sr"></param>
        /// <returns></returns>
        public static Models.SignatureRequest<T> ReadSignatureRequest<T>(string sr)
        {
            using (var mem = new MemoryStream(UnicodeEncoding.ASCII.GetBytes(sr)))
            using (var reader = new StreamReader(mem))
            {
                return ReadSignatureRequest<T>(reader);
            }
        }

        /// <summary>
        /// Reads the Signature Request
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="reader"></param>
        /// <returns></returns>
        public static Models.SignatureRequest<T> ReadSignatureRequest<T>(StreamReader reader)
        {
            return Common.ReadSignature<Models.SignatureRequest<T>>(reader);
        }
    }
}
