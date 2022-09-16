using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CoiNYC.Core.Cryptography
{
    public interface IHash64Algorithm
    {
        UInt64 Hash(String value);
        UInt64 Hash(byte[] value);
        UInt64 Hash(StringBuilder stringBuilder);
    }
}
