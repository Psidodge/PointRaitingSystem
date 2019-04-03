using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;
using MainLib.DBServices;

namespace MainLib.Auth
{
    public static class Auth
    {
        public static bool WasAuthenticated(string login, string password)
        {
            AuthInfo authInfo;
            try
            {
                authInfo = DataService.SelectAuthInfoByLogin(login);
            }
            catch (Exception e)
            {
                throw new DataBaseConnetionException("Cannot reach the database", e);
            }

            if (authInfo == null)
                throw new QueryResultIsNullException();

            byte[] salt = authInfo.salt,
                   passHash = authInfo.hash;
            if (salt == null || passHash == null)
                throw new NullReferenceException();

            byte[] enterdPassHash = GetComputedHash(password, salt);
            return enterdPassHash.SequenceEqual(passHash);
        }
        private static byte[] GetComputedHash(string password, byte[] salt)
        {
            byte[] saltedPass = Encoding.UTF8.GetBytes(password).Concat(salt).ToArray();
            HashAlgorithm hashProvider = new SHA512Managed();
            byte[] hashedPass = hashProvider.ComputeHash(saltedPass);
            hashProvider.Dispose();
            return hashedPass;
        }

        [Serializable]
        public class QueryResultIsNullException : Exception
        {
            public QueryResultIsNullException() { }
            public QueryResultIsNullException(string message) : base(message) { }
            public QueryResultIsNullException(string message, Exception inner) : base(message, inner) { }
            protected QueryResultIsNullException(
              System.Runtime.Serialization.SerializationInfo info,
              System.Runtime.Serialization.StreamingContext context) : base(info, context) { }
        }
        [Serializable]
        public class DataBaseConnetionException : Exception
        {
            public DataBaseConnetionException() { }
            public DataBaseConnetionException(string message) : base(message) { }
            public DataBaseConnetionException(string message, Exception inner) : base(message, inner) { }
            protected DataBaseConnetionException(
              System.Runtime.Serialization.SerializationInfo info,
              System.Runtime.Serialization.StreamingContext context) : base(info, context) { }
        }
    }
}