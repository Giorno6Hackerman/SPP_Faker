using System;
using System.Collections.Generic;
using System.Text;

namespace FakerLibrary
{
    public static class Generator
    {
        private static Random _rand = new Random();

        public static bool GenerateBoolean()
        {
            return _rand.Next(2) == 1;
        }

        public static byte GenerateByte()
        {
            return (byte)_rand.Next(Byte.MaxValue + 1);
        }

        public static char GenerateChar()
        {
            return (char)_rand.Next(Char.MaxValue + 1);
        }
        
        public static short GenerateSByte()
        {
            return (short)_rand.Next(-Byte.MaxValue / 2, Byte.MaxValue / 2);
        }

        public static short GenerateInt16()
        {
            return (short)_rand.Next(Int16.MinValue, Int16.MaxValue);
        }

        public static UInt16 GenerateUInt16()
        {
            return (UInt16)_rand.Next(UInt16.MinValue, UInt16.MaxValue);
        }

        public static int GenerateInt32()
        {
            return (int)_rand.Next(Int32.MinValue, Int32.MaxValue);
        }

        public static UInt32 GenerateUInt32()
        {
            return (UInt32)((_rand.Next(1 << 30) << 2) | _rand.Next(1 << 2));
        }

        public static Int64 GenerateInt64()
        {
            return (long)((_rand.Next(1 << 30) << 34) | (_rand.Next(1 << 30) << 4) | _rand.Next(1 << 4));
        }

        public static UInt64 GenerateUInt64()
        {
            return (ulong)((_rand.Next(1 << 30) << 34) | (_rand.Next(1 << 30) << 4) | _rand.Next(1 << 4));
        }

        public static Single GenerateSingle()
        {
            var buffer = new byte[4];
            _rand.NextBytes(buffer);
            return BitConverter.ToSingle(buffer, 0);
        }

        public static Double GenerateDouble()
        {
            var buffer = new byte[8];
            _rand.NextBytes(buffer);
            return BitConverter.ToDouble(buffer, 0);
        }

        public static Decimal GenerateDecimal()
        {
            return new decimal(_rand.Next(), _rand.Next(), _rand.Next(), _rand.Next(2) == 1, (byte)_rand.Next(29));
        }

        public static DateTime GenerateDateTime()
        {
            return new DateTime((_rand.Next(1 << 30) << 34) | (_rand.Next(1 << 30) << 4) | _rand.Next(1 << 4));
        }

        public static string GenerateString()
        {
            return "";
        }

        public static byte GenerateList()
        {
            return 0;
        }
    }
}
