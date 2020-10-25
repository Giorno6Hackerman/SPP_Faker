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
            return (_rand.Next(2) == 0) ? false : true;
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
            return (UInt32)(_rand.Next(Int32.MaxValue) >> 1 + _rand.Next(Int32.MaxValue));
        }

        public static Int64 GenerateInt64()
        {
            return 0;
        }

        public static UInt64 GenerateUInt64()
        {
            return 0;
        }

        public static Single GenerateSingle()
        {
            return 0;
        }

        public static Double GenerateDouble()
        {
            return 0;
        }

        public static Decimal GenerateDecimal()
        {
            return 0;
        }

        public static DateTime GenerateDateTime()
        {
            return DateTime.Now;
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
