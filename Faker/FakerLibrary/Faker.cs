using System;

namespace FakerLibrary
{
    public class Faker
    {
        public delegate object Generate();


        public Faker()
        { 
        
        }

        public static Generate GetGenerator(Type type)
        {
            
            return null;
        }
    }
}
