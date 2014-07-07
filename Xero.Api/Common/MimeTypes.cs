using System.IO;
using Microsoft.Win32;

namespace Xero.Api.Common
{
    public static class MimeTypes
    {
        public const string TextXml = "text/xml";
        public const string TextCsv = "text/csv";

        public const string ApplicationPdf = "application/pdf";
        public const string ApplicationJson = "application/json";

        public const string ImageTiff = "image/tiff";
        public const string ImagePng = "image/png";
        public const string ImageGif = "image/gif";
        public const string ImageJpeg = "image/jpeg";
        public const string ImageBmp = "image/bmp";

        public const string Unknown = "application/octet-stream";
        
        // Taken from http://stackoverflow.com/questions/58510/using-net-how-can-you-find-the-mime-type-of-a-file-based-on-the-file-signature
        public static string GetMimeType(FileInfo fileInfo)
        {
            string mimeType = "application/unknown";

            RegistryKey regKey = Registry.ClassesRoot.OpenSubKey(fileInfo.Extension.ToLower(), RegistryKeyPermissionCheck.ReadSubTree);

            if (regKey != null)
            {
                object contentType = regKey.GetValue("Content Type");

                if (contentType != null)
                    mimeType = contentType.ToString();
            }

            return mimeType;
        }

        public static string GetMimeType(string fileName)
        {
            return GetMimeType(new FileInfo(fileName));
        }
    }
}