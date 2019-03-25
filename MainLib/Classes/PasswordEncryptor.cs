using System.Linq;
using System.Security.Cryptography;
using System.Text;

namespace MainLib.Hashing
{
    public static class PasswordHashing
    {
        const int saltLen = 10;

        public static byte[] GetHashedPassword(string pass)
        {
            byte[] saltedPass = Encoding.UTF8.GetBytes(pass).Concat(GenerateSalt()).ToArray(),
                   hashedPass = null;

            using (HashAlgorithm hashAlgorithm = new SHA512Managed())
            {
                hashedPass = hashAlgorithm.ComputeHash(saltedPass);
            }

            return hashedPass;
        }
        public static byte[] GetHashedPassword(string pass, out byte[] salt)
        {
            salt = GenerateSalt();
            byte[] saltedPass = Encoding.UTF8.GetBytes(pass).Concat(salt).ToArray(),
                   hashedPass = null;

            using (HashAlgorithm hashAlgorithm = new SHA512Managed())
            {
                hashedPass = hashAlgorithm.ComputeHash(saltedPass);
            }

            return hashedPass;
        }
        public static byte[] GenerateSalt()
        {
            byte[] salt = new byte[saltLen];
            using (var rand = new RNGCryptoServiceProvider())
            {
                rand.GetNonZeroBytes(salt);
            }
            return salt;
        }
    }
}
