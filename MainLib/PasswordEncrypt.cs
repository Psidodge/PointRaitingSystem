using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;

namespace MainLib
{
    public class PasswordEncrypt
    {
        private HashAlgorithm hashProvider;
        private byte[] passwordHash;

        public PasswordEncrypt()
        {
            this.hashProvider = new SHA512Managed();
        }

        public void Encrypt(string pass)
        {
            this.passwordHash = new byte[Encoding.UTF8.GetByteCount(pass)];
            this.passwordHash = hashProvider.ComputeHash(Encoding.UTF8.GetBytes(pass));
        }
    }
}