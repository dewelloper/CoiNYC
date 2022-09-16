using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CoiNYC.Core.Cryptography
{
    public interface IHashAlgorithm
    {
        String Hash(String value);
        String Hash(byte[] value);

        String Hash(StringBuilder stringBuilder);
    }
}
