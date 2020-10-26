using System;
using FakerLibrary;

namespace Plugins
{
    public class Int32Generator : IGenerator
    {
        public object GenerateValue(Random random)
        {
            return (Int32)random.Next(Int32.MinValue, Int32.MaxValue);
        }

        public Type GetTypeOfValue()
        {
            return typeof(Int32);
        }
    }
}
