using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CoiNYC.Core.Cryptography
{
    public interface ICryptAlgorithm
    {
        String Encrypt(String value);
        String Decrypt(String value);
    }
}
