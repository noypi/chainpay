namespace ChainPay
{
    using System;
    using System.IO;
    using System.IO.Compression;
    using System.Text;
    using Newtonsoft.Json;

    public class Common
    {
        public static readonly string IGNORELINES_PREFIX = "----";

        public static string CreateSignature<M>(M res, string contentType)
        {
            string base64 = Convert.ToBase64String(Common.SerializeToJsonGz<M>(res));
            var strbuf = new StringBuilder();

            var beginstr = $"--------------- BEGIN ChainPay {contentType} ---------------";
            var endstr = $"--------------- END   ChainPay {contentType} ---------------";
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

        internal static M ReadSignature<M>(StreamReader reader)
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

            byte[] jsongz = Convert.FromBase64String(strbuf.ToString());
            return DeserializeToJsonGz<M>(jsongz);
        }

        internal static byte[] SerializeToJsonGz<M>(M req)
        {
            byte[] gzbytes = null;

            using (var mem = new MemoryStream())
            {
                using (var gzwriter = new GZipStream(mem, CompressionLevel.Fastest))
                using (var writer = new StreamWriter(gzwriter, UnicodeEncoding.UTF8))
                {
                    var json = JsonConvert.SerializeObject(req);
                    writer.Write(json);
                    writer.Flush();
                }
                gzbytes = mem.ToArray();
            }

            return gzbytes;
        }

        internal static M DeserializeToJsonGz<M>(byte[] jsongz)
        {
            using (var mem = new MemoryStream(jsongz))
            using (var gzreader = new GZipStream(mem, CompressionMode.Decompress))
            using (var reader = new StreamReader(gzreader, UnicodeEncoding.UTF8))
            {
                var json = reader.ReadToEnd();
                return JsonConvert.DeserializeObject<M>(json);
            }
        }
    }
}
