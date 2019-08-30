using System;
using System.IO;
using System.Linq;
using FormsClipboard = System.Windows.Forms.Clipboard;

namespace ClipUp.Windows
{
    public enum ClipboardType
    {
        Empty,
        Text,
        Image
    }

    public static class Clipboard
    {
        public static Tuple<ClipboardType, object> DetectType()
        {
            if (FormsClipboard.ContainsText())
            {
                return new Tuple<ClipboardType, object>(ClipboardType.Text, FormsClipboard.GetText());
            }
            else if (FormsClipboard.ContainsImage())
            {
                return new Tuple<ClipboardType, object>(ClipboardType.Image, FormsClipboard.GetImage());
            }
            else if (FormsClipboard.ContainsFileDropList())
            {
                var file = FormsClipboard.GetFileDropList()[0]; // TODO: Handle multiple files

                // TODO: Check for image

                if (!File.Exists(file))
                {
                    return new Tuple<ClipboardType, object>(ClipboardType.Empty, null);
                }

                var content = File.ReadAllText(file);

                if (HasBinaryContent(content))
                {
                    return new Tuple<ClipboardType, object>(ClipboardType.Empty, null);
                }

                return new Tuple<ClipboardType, object>(ClipboardType.Text, content);
            }
            else
            {
                return new Tuple<ClipboardType, object>(ClipboardType.Empty, null);
            }
        }
        
        private static bool HasBinaryContent(string content)
        {
            return content.Any(ch => char.IsControl(ch) && ch != '\r' && ch != '\n');
        }
    }
}
