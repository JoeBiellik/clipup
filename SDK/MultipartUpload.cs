using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace ClipUp.Sdk
{
    public class MultiPartUpload
    {
        private readonly string boundary;
        private readonly string boundaryCode;

        public IList<MultiPartFile> Files { get; } = new List<MultiPartFile>();
        public IDictionary<string, object> Forms { get; } = new Dictionary<string, object>();

        public string ContentType => $"multipart/form-data; boundary=--------------{this.boundaryCode}";

        public long ContentLength
        {
            get
            {
                var ascii = new ASCIIEncoding();
                long contentLength = ascii.GetBytes(this.boundary).Length;

                foreach (var form in this.Forms)
                {
                    contentLength += ascii.GetBytes(CreateFormBoundaryHeader(form.Key, form.Value)).Length;
                    contentLength += ascii.GetBytes(this.boundary).Length;
                }

                foreach (var file in this.Files)
                {
                    contentLength += ascii.GetBytes(CreateFileBoundaryHeader(file)).Length;
                    contentLength += file.Data.Length;
                    contentLength += ascii.GetBytes(this.boundary).Length;
                }

                contentLength += ascii.GetBytes("--").Length;

                return contentLength;
            }
        }

        public byte[] RequestData
        {
            get
            {
                using (var stream = new MemoryStream())
                {
                    stream.WriteString(this.boundary);

                    foreach (var form in this.Forms)
                    {
                        stream.WriteString(CreateFormBoundaryHeader(form.Key, form.Value));
                        stream.WriteString(this.boundary);
                    }

                    foreach (var file in this.Files)
                    {
                        stream.WriteString(CreateFileBoundaryHeader(file));
                        StreamFileContents(file.Data, file, stream);
                        stream.WriteString(this.boundary);
                    }

                    stream.WriteString("--");

                    return stream.ToArray();
                }
            }
        }

        public MultiPartUpload()
        {
            this.boundaryCode = DateTime.Now.Ticks.GetHashCode() + "548130";
            this.boundary = $"\r\n----------------{this.boundaryCode}";
        }

        private static string CreateFileBoundaryHeader(MultiPartFile multiPartFile)
        {
            return $"\r\nContent-Disposition: form-data; name=\"{multiPartFile.FieldName}\"; filename=\"{Path.GetFileName(multiPartFile.FileName)}\"\r\n" + $"Content-Type: {multiPartFile.ContentType}\r\n" + $"Content-Transfer-Encoding: {multiPartFile.ContentTransferEncoding}\r\n\r\n";
        }

        private static string CreateFormBoundaryHeader(string name, object value)
        {
            return $"\r\nContent-Disposition: form-data; name=\"{name}\"\r\n\r\n{value}";
        }
        
        private static void StreamFileContents(byte[] data, MultiPartFile file, Stream stream)
        {
            switch (file.ContentTransferEncoding)
            {
                case "base64":
                    stream.WriteString(Convert.ToBase64String(data, 0, data.Length));
                    break;
                case "binary":
                    stream.Write(data, 0, data.Length);
                    break;
                default:
                    throw new Exception($"Unknown transfer encoding: {file.ContentTransferEncoding}");
            }
        }
    }
}
