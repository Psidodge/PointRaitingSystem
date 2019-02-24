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
            List<AuthInfo> authInfos;
            try
            {
                authInfos = DataService.SelectAuthInfoByLogin(login);
            }
            catch (Exception e)
            {
                throw new DataBaseConnetionException("Cannot reach the database", e);
            }

            if (authInfos.Count == 0)
                throw new QueryResultIsNullException();

            byte[] salt = authInfos[0].Salt,
                   passHash = authInfos[0].Pass_hash;
            if (salt == null || passHash == null)
                throw new NullReferenceException(string.Format("Error in WasAuthenticated() where 'salt' is {0}; 'passHash' is {1}", salt, passHash)); //NOTE: Debug info need to delete before realese

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