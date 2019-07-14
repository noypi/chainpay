namespace ChainPay
{
    using global::ChainPay.Models;
    using Google.Protobuf;
    using System;
    using System.IO;
    using System.IO.Compression;
    using System.Text;

    public class Common
    {
        public static readonly string IGNORELINES_PREFIX = "#-- ";

        public static string CreateSignature(IMessage res, string contentType)
        {
            string base64 = Convert.ToBase64String(Common.SerializeToGz(res));
            var strbuf = new StringBuilder();

            var beginstr = $"#-- BEGIN ChainPay {contentType}";
            var endstr = $"#-- END   ChainPay {contentType}";
            strbuf.Append(beginstr);
            strbuf.AppendLine();

            int nRemaining = base64.Length;
            for (int i = 0; i < base64.Length;)
            {
                int nToWrite = Math.Min(beginstr.Length, nRemaining);
                strbuf.Append(base64.Substring(i, nToWrite));
                strbuf.AppendLine();

                i += nToWrite;
                nRemaining -= nToWrite;
            }

            strbuf.Append(endstr);

            return strbuf.ToString();
        }

        internal static IMessage ReadSignature(MessageParser parser, StreamReader reader)
        {
            var strbuf = new StringBuilder();

            string base64 = string.Empty;
            string line = string.Empty;
            while ((line = reader.ReadLine()) != null)
            {
                line = line.Trim();
                if (line.StartsWith(IGNORELINES_PREFIX) ||
                    string.IsNullOrEmpty(line))
                {
                    continue;
                }

                strbuf.Append(line.Trim());
            }

            byte[] gz = Convert.FromBase64String(strbuf.ToString());
            return DeserializeGz(parser, gz);
        }

        internal static byte[] SerializeToGz(IMessage req)
        {
            byte[] gzbytes = null;
            
            using (var mem = new MemoryStream())
            {
                var data = req.ToByteArray();
                using (var gzwriter = new GZipStream(mem, CompressionLevel.Fastest))
                using (var writer = new BinaryWriter(gzwriter))
                {
                    writer.Write(data);
                    writer.Flush();
                }

                gzbytes = mem.ToArray();
            }

            return gzbytes;
        }

        internal static IMessage DeserializeGz(MessageParser parser, byte[] jsongz)
        {
            using (var mem = new MemoryStream(jsongz))
            using (var gzreader = new GZipStream(mem, CompressionMode.Decompress))
            using (var outmem = new MemoryStream())
            {
                gzreader.CopyTo(outmem);
                var data = outmem.ToArray();
                return parser.ParseFrom(data);
            }
        }
    }
}
