using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CoiNYC.Core.Cryptography
{
    public class FastHash : IHash64Algorithm
    {
        const UInt64 k0 = 0xc3a5c85c97cb3127;
        const UInt64 k1 = 0xb492b66fbe98f273;
        const UInt64 k2 = 0x9ae16a3b2f90404f;

        struct UInt128
        {
            public UInt64 High64;
            public UInt64 Low64;
            public UInt128(UInt64 low, UInt64 high)
            {
                High64 = high;
                Low64 = low;
            }
        }

        public UInt64 Hash(string value)
        {
            byte[] buffer = Encoding.Unicode.GetBytes(value);
            return Hash(buffer);
        }

        public UInt64 Hash(StringBuilder stringBuilder)
        {
            byte[] buffer = Encoding.Unicode.GetBytes(stringBuilder.ToString());
            return Hash(buffer);
        }

        public UInt64 Hash(byte[] buffer)
        {

            int len = buffer.Length;
            if (len <= 32)
            {
                if (len <= 16)
                {
                    return HashLen0to16(buffer, len);
                }
                else
                {
                    return HashLen17to32(buffer, len);
                }
            }
            else if (len <= 64)
            {
                return HashLen33to64(buffer, len);
            }

            //// For strings over 64 bytes we hash the end first, and then as we
            //// loop we keep 56 bytes of state: v, w, x, y, and z.
            UInt64 x = Fetch64(buffer, len - 40);
            UInt64 y = Fetch64(buffer, len - 16) + Fetch64(buffer, len - 56);
            UInt64 z = HashLen16(Fetch64(buffer, len - 48) + Convert.ToUInt64(len), Fetch64(buffer, len - 24));
            UInt128 v = WeakHashLen32WithSeeds(buffer, len - 64, Convert.ToUInt64(len), z);
            UInt128 w = WeakHashLen32WithSeeds(buffer, len - 32, y + k1, x);
            x = x * k1 + Fetch64(buffer);

            UInt64 temp;
            //// Decrease len to the nearest multiple of 64, and operate on 64-byte chunks.
            len = (len - 1) & ~(63);
            int offset = 0;
            do
            {
                x = Rotate(x + y + v.Low64 + Fetch64(buffer, offset + 8), 37) * k1;
                y = Rotate(y + v.High64 + Fetch64(buffer, offset + 48), 42) * k1;
                x ^= w.High64;
                y += v.Low64 + Fetch64(buffer, offset + 40);
                z = Rotate(z + w.Low64, 33) * k1;
                v = WeakHashLen32WithSeeds(buffer, offset, v.Low64 * k1, x + w.Low64);
                w = WeakHashLen32WithSeeds(buffer, offset + 32, z + w.High64, y + Fetch64(buffer, offset + 16));
                temp = z;
                z = x;
                x = temp;
                offset += 64;
                len -= 64;
            } while (len != 0);
            return HashLen16(HashLen16(v.Low64, w.High64) + ShiftMix(y) * k1 + z,
                             HashLen16(v.High64, w.High64) + x);

        }

        static uint SwapBytes(uint x)
        {
            // swap adjacent 16-bit blocks
            x = (x >> 16) | (x << 16);
            // swap adjacent 8-bit blocks
            return ((x & 0xFF00FF00) >> 8) | ((x & 0x00FF00FF) << 8);
        }

        static ulong SwapBytes(ulong x)
        {
            // swap adjacent 32-bit blocks
            x = (x >> 32) | (x << 32);
            // swap adjacent 16-bit blocks
            x = ((x & 0xFFFF0000FFFF0000) >> 16) | ((x & 0x0000FFFF0000FFFF) << 16);
            // swap adjacent 8-bit blocks
            return ((x & 0xFF00FF00FF00FF00) >> 8) | ((x & 0x00FF00FF00FF00FF) << 8);
        }


        static UInt64 Fetch64(byte[] p, int offset = 0)
        {
            return BitConverter.ToUInt64(p, offset);
        }

        static UInt32 Fetch32(byte[] p, int offset = 0)
        {
            return BitConverter.ToUInt32(p, offset);
        }

        static UInt64 Rotate(UInt64 val, int shift)
        {
            // Avoid shifting by 64: doing so yields an undefined result.
            return shift == 0 ? val : ((val >> shift) | (val << (64 - shift)));
        }


        static UInt64 Hash128to64(UInt128 x)
        {
            // Murmur-inspired hashing.
            const UInt64 kMul = 0x9ddfea08eb382d69UL;
            UInt64 a = (x.Low64 ^ x.High64) * kMul;
            a ^= (a >> 47);
            UInt64 b = (x.High64 ^ a) * kMul;
            b ^= (b >> 47);
            b *= kMul;
            return b;
        }

        static UInt64 HashLen16(UInt64 u, UInt64 v)
        {
            return Hash128to64(new UInt128(u, v));
        }

        static UInt64 HashLen16(UInt64 u, UInt64 v, UInt64 mul)
        {
            // Murmur-inspired hashing.
            UInt64 a = (u ^ v) * mul;
            a ^= (a >> 47);
            UInt64 b = (v ^ a) * mul;
            b ^= (b >> 47);
            b *= mul;
            return b;
        }

        static UInt64 ShiftMix(UInt64 val)
        {
            return val ^ (val >> 47);
        }

        static UInt64 HashLen0to16(byte[] s, int len)
        {
            if (len >= 8)
            {
                UInt64 mul = k2 + Convert.ToUInt64(len) * 2;
                UInt64 a = Fetch64(s) + k2;
                UInt64 b = Fetch64(s, len - 8);
                UInt64 c = Rotate(b, 37) * mul + a;
                UInt64 d = (Rotate(a, 25) + b) * mul;
                return HashLen16(c, d, mul);
            }
            if (len >= 4)
            {
                UInt64 mul = k2 + Convert.ToUInt64(len) * 2;
                UInt64 a = Fetch32(s);
                return HashLen16(Convert.ToUInt64(len) + (a << 3), Fetch32(s, len - 4), mul);
            }
            if (len > 0)
            {
                byte a = s[0];
                byte b = s[len >> 1];
                byte c = s[len - 1];
                UInt32 y = (UInt32)(a) + ((UInt32)(b) << 8);
                UInt32 z = Convert.ToUInt32(len) + Convert.ToUInt32(c << 2);

                return ShiftMix(y * k2 ^ z * k0) * k2;
            }
            return k2;
        }

        static UInt64 HashLen17to32(byte[] s, int len)
        {
            UInt64 mul = k2 + Convert.ToUInt64(len) * 2;
            UInt64 a = Fetch64(s) * k1;
            UInt64 b = Fetch64(s, 8);
            UInt64 c = Fetch64(s, len - 8) * mul;
            UInt64 d = Fetch64(s, len - 16) * k2;
            return HashLen16(Rotate(a + b, 43) + Rotate(c, 30) + d,
                             a + Rotate(b + k2, 18) + c, mul);
        }

        static UInt64 HashLen33to64(byte[] s, int len)
        {
            UInt64 mul = k2 + Convert.ToUInt64(len) * 2;
            UInt64 a = Fetch64(s) * k2;
            UInt64 b = Fetch64(s, 8);
            UInt64 c = Fetch64(s, len - 24);
            UInt64 d = Fetch64(s, len - 32);
            UInt64 e = Fetch64(s, 16) * k2;
            UInt64 f = Fetch64(s, 24) * 9;
            UInt64 g = Fetch64(s, len - 8);
            UInt64 h = Fetch64(s, len - 16) * mul;
            UInt64 u = Rotate(a + g, 43) + (Rotate(b, 30) + c) * 9;
            UInt64 v = ((a + g) ^ d) + f + 1;
            UInt64 w = SwapBytes((u + v) * mul) + h;
            UInt64 x = Rotate(e + f, 42) + c;
            UInt64 y = (SwapBytes((v + w) * mul) + g) * mul;
            UInt64 z = e + f + c;
            a = SwapBytes((x + z) * mul + y) + b;
            b = ShiftMix((z + a) * mul + d + h) * mul;
            return b + x;
        }

        static UInt128 WeakHashLen32WithSeeds(UInt64 w, UInt64 x, UInt64 y, UInt64 z, UInt64 a, UInt64 b)
        {
            a += w;
            b = Rotate(b + a + z, 21);
            UInt64 c = a;
            a += x;
            a += y;
            b += Rotate(a, 44);
            return new UInt128(a + z, b + c);
        }

        // Return a 16-byte hash for s[0] ... s[31], a, and b.  Quick and dirty.
        static UInt128 WeakHashLen32WithSeeds(
            byte[] s, int offset, UInt64 a, UInt64 b)
        {
            return WeakHashLen32WithSeeds(Fetch64(s, offset),
                                          Fetch64(s, offset + 8),
                                          Fetch64(s, offset + 16),
                                          Fetch64(s, offset + 24),
                                          a,
                                          b);
        }

    }
}
