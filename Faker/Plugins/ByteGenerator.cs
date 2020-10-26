using FakerLibrary;
using System;

namespace Plugins
{
    public class ByteGenerator : IGenerator
    {
        public object GenerateValue(Random random)
        {
            return (byte)random.Next(Byte.MaxValue + 1);
        }

        public Type GetTypeOfValue()
        {
            return typeof(Byte);
        }
    }
}
