using System;
using System.Collections.Generic;
using System.Text;

namespace FakerLibrary
{
    public static class ListGenerator
    {
        private static Random _rand = new Random();

        
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
