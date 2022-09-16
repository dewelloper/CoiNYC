using CoiNYC.Core.Cryptography;

namespace CoiNYC.Core.Extensions
{
    public static class CryptographyExtensions
    {
        private static readonly DesAlgorithm desAlgorithm = new DesAlgorithm();
        public static string DecryptDes(this string value)
        {
            return desAlgorithm.Decrypt(value).ConvertFromBase64();
        }
        public static string EncryptDes(this string value)
        {
            return desAlgorithm.Encrypt(value).ConvertToBase64();
        }
    }
}
