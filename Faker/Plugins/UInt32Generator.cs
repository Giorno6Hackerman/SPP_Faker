using System;
using FakerLibrary;

namespace Plugins
{
    public class UInt32Generator : IGenerator
    {
        public object GenerateValue(Random random)
        {
            return (UInt32)((random.Next(1 << 30) << 2) | random.Next(1 << 2));
        }

        public Type GetTypeOfValue()
        {
            return typeof(UInt32);
        }
    }
}
