namespace ClipUp.Sdk
{
    public class MultiPartFile
    {
        public string FieldName { get; set; }
        public string FileName { get; set; }
        public byte[] Data { get; set; }
        public string ContentType { get; set; }
        public string ContentTransferEncoding { get; set; } = "binary";
    }
}
