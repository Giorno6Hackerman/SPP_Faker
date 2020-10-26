using System;
using System.Collections.Generic;
using System.Collections;
using System.Text;

namespace FakerLibrary
{
    public static class ListGenerator
    {
        // определять тип элементов и вызывать сответствующий генератор
        public static object GenerateList(Random random, Type type)
        {
            int size = random.Next(Byte.MaxValue);
            object list = (IList)Activator.CreateInstance(typeof(List<>).MakeGenericType(type));
            for (int i = 0; i < size; i++)
            {
                ((IList)list).Add(Generator.GetGenerator(type));
            }
            return list;
        }
    }
}
