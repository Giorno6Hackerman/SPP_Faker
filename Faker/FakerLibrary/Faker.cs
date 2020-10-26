using System;

namespace FakerLibrary
{
    public class Faker
    {
        public delegate T Generate<T>();

        public Faker()
        { 
        
        }

        public static Generate<T> GetGenerator<T>()
        {
            return null;
        }
    }
}
