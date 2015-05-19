using System;

namespace Xero.Api.Example.Applications.Private
{
    public class SigningCertificate
    {
        private static readonly string NO_PASSWORD = null;
        public string Path { get; private set; }
        public string Password { get; private set; }

        public SigningCertificate(string path) : this(path, NO_PASSWORD)
        { }

        public SigningCertificate(string path, string password)
        {
            if (string.IsNullOrEmpty(path))
                throw new ArgumentException("Cannot create without a file path", "path");

            Path = System.IO.Path.GetFullPath(path);
            Password = password;
        }
    }
}