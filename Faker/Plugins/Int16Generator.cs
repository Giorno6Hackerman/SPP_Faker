using System;
using FakerLibrary;

namespace Plugins
{
    public class Int16Generator : IGenerator
    {
        public object GenerateValue(Random random)
        {
            return (Int16)random.Next(Int16.MinValue, Int16.MaxValue);
        }

        public Type GetTypeOfValue()
        {
            return typeof(Int16);
        }
    }
}
