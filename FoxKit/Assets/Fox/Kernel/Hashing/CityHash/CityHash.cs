#region License
// Copyright (c) 2011 Google, Inc.
// Copyright (c) 2014 Atvaark
//
// Permission is hereby granted, free of charge, to any person obtaining a copy
// of this software and associated documentation files (the "Software"), to deal
// in the Software without restriction, including without limitation the rights
// to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
// copies of the Software, and to permit persons to whom the Software is
// furnished to do so, subject to the following conditions:
//
// The above copyright notice and this permission notice shall be included in
// all copies or substantial portions of the Software.
//
// THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
// IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
// FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
// AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
// LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
// OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN
// THE SOFTWARE.
//
// CityHash, by Geoff Pike and Jyrki Alakuijala
// CityHash C# Port, by Atvaark
//
// This file provides CityHash64() and related functions.
//
// It's probably possible to create even faster hash functions by
// writing a program that systematically explores some of the space of
// possible hash functions, by using SIMD instructions, or by
// compromising on hash quality.
#endregion
using System;
using System.Text;
using uint8 = System.Byte;
using uint32 = System.UInt32;
using uint64 = System.UInt64;
using uint128 = CityHash.UInt128;

namespace CityHash
{
    /// <summary>
    ///     Managed CityHash 1.0.3 implementation.
    /// </summary>
    public static class CityHash
    {
        // Some primes between 2^63 and 2^64 for various uses.
        private const uint64 K0 = 0xc3a5c85c97cb3127;
        private const uint64 K1 = 0xb492b66fbe98f273;
        private const uint64 K2 = 0x9ae16a3b2f90404f;
        private const uint64 K3 = 0xc949d7c7509e6557;
        
        // Hash 128 input bits down to 64 bits of output.
        // This is intended to be a reasonably good hash function.
        private static uint64 Hash128To64(uint128 x)
        {
            // Murmur-inspired hashing.
            const ulong kMul = 0x9ddfea08eb382d69;
            ulong a = (Uint128Low64(x) ^ Uint128High64(x))*kMul;
            a ^= (a >> 47);
            ulong b = (Uint128High64(x) ^ a)*kMul;
            b ^= (b >> 47);
            b *= kMul;
            return b;
        }

        private static uint64 RotateByAtLeast1(uint64 val, int shift)
        {
            return (val >> shift) | (val << (64 - shift));
        }

        private static uint64 Uint128Low64(uint128 x)
        {
            return x.Low;
        }

        private static uint64 Uint128High64(uint128 x)
        {
            return x.High;
        }

        private static uint128 make_pair(uint64 low, uint64 high)
        {
            return new uint128(low, high);
        }

        private static uint64 Fetch64(ReadOnlySpan<byte> p, int index)
        {
            return BitConverter.ToUInt64(p.Slice(index));
        }

        private static uint64 Fetch64(ReadOnlySpan<byte> p, uint index)
        {
            return Fetch64(p, (int) index);
        }

        private static uint32 Fetch32(ReadOnlySpan<byte> p, int index)
        {
            return BitConverter.ToUInt32(p.Slice(index));
        }

        private static void Swap<T>(ref T a, ref T b)
        {
            (a, b) = (b, a);
        }

        // Bitwise right rotate. Normally this will compile to a single
        // instruction, especially if the shift is a manifest constant.
        private static uint64 Rotate(uint64 val, int shift)
        {
            // Avoid shifting by 64: doing so yields an undefined result.
            return shift == 0 ? val : ((val >> shift) | (val << (64 - shift)));
        }

        private static uint64 ShiftMix(uint64 val)
        {
            return val ^ (val >> 47);
        }

        private static uint64 HashLen16(uint64 u, uint64 v)
        {
            return Hash128To64(new uint128(u, v));
        }

        private static uint64 HashLen0To16(ReadOnlySpan<byte> s, int offset)
        {
            int len = s.Length - offset;
            if (len > 8)
            {
                uint64 a = Fetch64(s, offset);
                uint64 b = Fetch64(s, offset + len - 8);
                return HashLen16(a, RotateByAtLeast1(b + (ulong) len, len)) ^ b;
            }
            if (len >= 4)
            {
                uint64 a = Fetch32(s, offset);
                return HashLen16((uint) len + (a << 3), Fetch32(s, offset + len - 4));
            }
            if (len > 0)
            {
                uint8 a = s[offset];
                uint8 b = s[offset + (len >> 1)];
                uint8 c = s[offset + (len - 1)];
                uint32 y = a + ((uint32) b << 8);
                uint32 z = (uint) len + ((uint32) c << 2);
                return ShiftMix(y*K2 ^ z*K3)*K2;
            }
            return K2;
        }

        // This probably works well for 16-byte strings as well, but it may be overkill
        // in that case.
        private static uint64 HashLen17To32(ReadOnlySpan<byte> s)
        {
            uint len = (uint) s.Length;
            uint64 a = Fetch64(s, 0)*K1;
            uint64 b = Fetch64(s, 8);
            uint64 c = Fetch64(s, len - 8)*K2;
            uint64 d = Fetch64(s, len - 16)*K0;
            return HashLen16(Rotate(a - b, 43) + Rotate(c, 30) + d,
                a + Rotate(b ^ K3, 20) - c + len);
        }

        // Return a 16-byte hash for 48 bytes. Quick and dirty.
        // Callers do best to use "random-looking" values for a and b.
        private static uint128 WeakHashLen32WithSeeds(
            uint64 w, uint64 x, uint64 y, uint64 z, uint64 a, uint64 b)
        {
            a += w;
            b = Rotate(b + a + z, 21);
            uint64 c = a;
            a += x;
            a += y;
            b += Rotate(a, 44);
            return make_pair(a + z, b + c);
        }

        // Return a 16-byte hash for s[0] ... s[31], a, and b. Quick and dirty.
        private static uint128 WeakHashLen32WithSeeds(ReadOnlySpan<byte> s, int offset, uint64 a, uint64 b)
        {
            return WeakHashLen32WithSeeds(Fetch64(s, offset),
                Fetch64(s, offset + 8),
                Fetch64(s, offset + 16),
                Fetch64(s, offset + 24),
                a,
                b);
        }

        // Return an 8-byte hash for 33 to 64 bytes.
        private static uint64 HashLen33To64(ReadOnlySpan<byte> s)
        {
            uint len = (uint) s.Length;
            uint64 z = Fetch64(s, 24);
            uint64 a = Fetch64(s, 0) + (len + Fetch64(s, len - 16))*K0;
            uint64 b = Rotate(a + z, 52);
            uint64 c = Rotate(a, 37);
            a += Fetch64(s, 8);
            c += Rotate(a, 7);
            a += Fetch64(s, 16);
            uint64 vf = a + z;
            uint64 vs = b + Rotate(a, 31) + c;
            a = Fetch64(s, 16) + Fetch64(s, len - 32);
            z = Fetch64(s, len - 8);
            b = Rotate(a + z, 52);
            c = Rotate(a, 37);
            a += Fetch64(s, len - 24);
            c += Rotate(a, 7);
            a += Fetch64(s, len - 16);
            uint64 wf = a + z;
            uint64 ws = b + Rotate(a, 31) + c;
            uint64 r = ShiftMix((vf + ws)*K2 + (wf + vs)*K0);
            return ShiftMix(r*K0 + vs)*K2;
        }

        private static uint64 CityHash64(ReadOnlySpan<byte> s)
        {
            int len = s.Length;
            if (len <= 32)
            {
                if (len <= 16)
                {
                    return HashLen0To16(s, 0);
                }
                return HashLen17To32(s);
            }
            if (len <= 64)
            {
                return HashLen33To64(s);
            }


            // For strings over 64 bytes we hash the end first, and then as we
            // loop we keep 56 bytes of state: v, w, x, y, and z.
            uint64 x = Fetch64(s, len - 40);
            uint64 y = Fetch64(s, len - 16) + Fetch64(s, len - 56);
            uint64 z = HashLen16(Fetch64(s, len - 48) + (ulong) len, Fetch64(s, len - 24));
            uint128 v = WeakHashLen32WithSeeds(s, len - 64, (ulong) len, z);
            uint128 w = WeakHashLen32WithSeeds(s, len - 32, y + K1, x);
            x = x*K1 + Fetch64(s, 0);

            // Decrease len to the nearest multiple of 64, and operate on 64-byte chunks.
            len = (s.Length - 1) & ~63;
            int offset = 0;
            do
            {
                x = Rotate(x + y + v.Low + Fetch64(s, offset + 8), 37)*K1;
                y = Rotate(y + v.High + Fetch64(s, offset + 48), 42)*K1;
                x ^= w.High;
                y += v.Low + Fetch64(s, offset + 40);
                z = Rotate(z + w.Low, 33)*K1;
                v = WeakHashLen32WithSeeds(s, offset, v.High*K1, x + w.Low);
                w = WeakHashLen32WithSeeds(s, offset + 32, z + w.High, y + Fetch64(s, offset + 16));
                Swap(ref z, ref x);
                offset += 64;
                len -= 64;
            } while (len != 0);
            return HashLen16(HashLen16(v.Low, w.Low) + ShiftMix(y)*K1 + z,
                HashLen16(v.High, w.High) + x);
        }

        // Hash function for a byte array. For convenience, two seeds are also
        // hashed into the result.
        public static uint64 CityHash64WithSeeds(ReadOnlySpan<char> s, uint64 seed0, uint64 seed1)
        {
            string TEMP = new string(s);
            return CityHash64WithSeeds(TEMP, seed0, seed1, Encoding.Default);
        }
        public static uint64 CityHash64WithSeeds(string s, uint64 seed0, uint64 seed1)
        {
            return CityHash64WithSeeds(s, seed0, seed1, Encoding.Default);
        }

        // Hash function for a string. For convenience, two seeds are also
        // hashed into the result.
        private static uint64 CityHash64WithSeeds(string s, uint64 seed0, uint64 seed1, Encoding encoding)
        {
            return CityHash64WithSeeds(encoding.GetBytes(s), seed0, seed1);
        }

        public static uint64 CityHash64WithSeeds(ReadOnlySpan<byte> s, uint64 seed0, uint64 seed1)
        {
            return HashLen16(CityHash64(s) - seed0, seed1);
        }
    }
}