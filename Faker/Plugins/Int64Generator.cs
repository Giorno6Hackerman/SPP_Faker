using System;
using FakerLibrary;

namespace Plugins
{
    public class Int64Generator : IGenerator
    {
        public object GenerateValue(Random random)
        {
            return (long)((random.Next(1 << 30) << 34) | (random.Next(1 << 30) << 4) | random.Next(1 << 4));
        }

        public Type GetTypeOfValue()
        {
            return typeof(Int64);
        }
    }
}
