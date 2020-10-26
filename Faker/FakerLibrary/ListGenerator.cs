using System;
using System.Collections.Generic;
using System.Text;

namespace FakerLibrary
{
    public static class ListGenerator
    {
        // определять тип элементов и вызывать сответствующий генератор
        public static List<T> GenerateList<T>(Random random)
        {
            int size = random.Next(Byte.MaxValue);
            List<T> list = new List<T>(size);
            for (int i = 0; i < size; i++)
            {
                list.Add((T)Faker.GetGenerator(typeof(T)).Invoke());
            }
            return list;
        }
    }
}
