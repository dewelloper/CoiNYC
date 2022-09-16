using System;
using System.Collections.Generic;
using System.Linq;
using App.Core.Configuration;

namespace CoiNYC.Core.Cryptography
{
    public abstract class CryptAlgorithmBase : ICryptAlgorithm
    {
        private Byte[] _KEY_64 = null;
        private Byte[] _IV_64 = null;


        protected abstract string AlgorithmName { get; }

        protected virtual Byte[] KEY_64
        {
            get
            {
                if (_KEY_64 == null)
                {
                    _KEY_64 = GetBytes(ConfigReader.GetString(AlgorithmName + "_KEY"));
                }
                return _KEY_64;
            }
        }

        public virtual Byte[] IV_64
        {
            get
            {
                if (_IV_64 == null)
                {
                    _IV_64 = GetBytes(ConfigReader.GetString(AlgorithmName + "_IV"));
                }
                return _IV_64;
            }
        }

        private static Byte[] GetBytes(string keyString)
        {
            var strKeyArray = keyString.Split(',');
            List<byte> result = new List<byte>();
            foreach (var item in strKeyArray)
            {
                result.Add(Convert.ToByte(item.Trim()));
            }
            return result.ToArray();
        }
        public abstract String Encrypt(String value);
        public abstract String Decrypt(String value);
    }
}
