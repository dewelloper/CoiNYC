using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;

namespace CoiNYC.Core.Cryptography
{
    public class RandomStringGenerator
    {
        private static readonly string _charSet = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ1234567890";

        public static string Generate(int length) {

            byte[] data = new byte[length];
            using (RNGCryptoServiceProvider crypto = new RNGCryptoServiceProvider())
            {
                crypto.GetNonZeroBytes(data);
            }

            StringBuilder result = new StringBuilder(length);

            foreach (byte b in data)
            {
                result.Append(_charSet[b % (_charSet.Length)]);
            }

            return result.ToString();
        }
    }
}
