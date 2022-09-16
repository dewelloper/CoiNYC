using System;
using System.Security.Cryptography;
using System.IO;
using System.Text;

namespace CoiNYC.Core.Cryptography
{
    public class SHA1Algorithm : IHashAlgorithm
    {
        public string Hash(string value)
        {
            if (value == null)
                value = String.Empty;

            byte[] bytes = Encoding.UTF8.GetBytes(value);
            return Hash(bytes);
        }

        public string Hash(byte[] value)
        {
            using (SHA1Managed hashstring = new SHA1Managed())
            {
                byte[] hash = hashstring.ComputeHash(value);
                string hashString = string.Empty;
                foreach (byte x in hash)
                {
                    hashString += String.Format("{0:x2}", x);
                }
                return hashString.ToUpper();
            }
        }

        public String Hash(StringBuilder stringBuilder)
        {
            byte[] bytes = Encoding.UTF8.GetBytes(stringBuilder.ToString());
            return Hash(bytes);
        }
    }
}
