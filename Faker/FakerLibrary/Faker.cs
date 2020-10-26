using System;
using System.Collections.Generic;

namespace FakerLibrary
{
    public class Faker
    {
        private Generator _generator;

        public Faker()
        {
            _generator = new Generator();
        }

        public T Create<T>()
        {
            return default(T);
        }

        public static object Create(Type type)
        {
            return null;
        }
    }
}
