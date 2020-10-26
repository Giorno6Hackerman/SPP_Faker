using System;
using System.Collections.Generic;
using System.Collections;

namespace FakerLibrary
{
    public static class ListGenerator
    {
        // определять тип элементов и вызывать сответствующий генератор
        public static object GenerateList(Random random, Type type)
        {
            int size = random.Next(Byte.MaxValue / 2);
            object list = (IList)Activator.CreateInstance(typeof(List<>).MakeGenericType(type));
            for (int i = 0; i < size; i++)
            {
                ((IList)list).Add(Generator.GetGeneratedValue(type));
            }
            return list;
        }
    }
}
