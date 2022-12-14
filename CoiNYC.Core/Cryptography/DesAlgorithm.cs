using System;
using System.Security.Cryptography;
using System.IO;

namespace CoiNYC.Core.Cryptography
{
    public class DesAlgorithm : CryptAlgorithmBase
    {
        public override string Encrypt(string value)
        {
            if (String.IsNullOrEmpty(value))
                return value;

            string result = string.Empty;
            using (DESCryptoServiceProvider cryptoProvider = new DESCryptoServiceProvider())
            {
                using (MemoryStream ms = new MemoryStream())
                {
                    CryptoStream cs = new CryptoStream(ms, cryptoProvider.CreateEncryptor(KEY_64, IV_64), CryptoStreamMode.Write);
                    StreamWriter sw = new StreamWriter(cs);
                    sw.Write(value);
                    sw.Flush();
                    cs.FlushFinalBlock();
                    ms.Flush();
                    int streamLength = (int)ms.Length;
                    result = Convert.ToBase64String(ms.GetBuffer(), 0, streamLength);
                }
            }
            return result;
        }
        public override string Decrypt(string value)
        {
            if (String.IsNullOrEmpty(value))
                return value;

            string result = string.Empty;
            using (DESCryptoServiceProvider cryptoProvider = new DESCryptoServiceProvider())
            {
                Byte[] buffer = Convert.FromBase64String(value);
                using (MemoryStream ms = new MemoryStream(buffer))
                {
                    CryptoStream cs = new CryptoStream(ms, cryptoProvider.CreateDecryptor(KEY_64, IV_64), CryptoStreamMode.Read);
                    StreamReader sr = new StreamReader(cs);
                    result = sr.ReadToEnd();
                }
            }
            return result;
        }

        protected override string AlgorithmName
        {
            get { return "DES"; }
        }
    }
}
