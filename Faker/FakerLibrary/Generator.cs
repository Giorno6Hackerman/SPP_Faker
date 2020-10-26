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

        // без пустой строки ?
        public static string GenerateString()
        {
            int size = _rand.Next(1024) + 1;
            byte[] buffer = new byte[size * 2];
            _rand.NextBytes(buffer);
            return Encoding.UTF8.GetString(buffer);
        }

        // определять тип элементов и вызывать сответствующий генератор
        public static List<T> GenerateList<T>()
        {
            int size = _rand.Next(Byte.MaxValue);
            List<T> list = new List<T>(size);
            for (int i = 0; i < size; i++)
            {
                list.Add(Faker.GetGenerator<T>().Invoke());
            }
            return list;
        }
    }
}
