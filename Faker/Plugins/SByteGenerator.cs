using System;
using FakerLibrary;

namespace Plugins
{
    public class SByteGenerator : IGenerator
    {
        public object GenerateValue(Random random)
        {
            return (short)random.Next(-Byte.MaxValue / 2, Byte.MaxValue / 2);
        }

        public Type GetTypeOfValue()
        {
            return typeof(SByte);
        }
    }
}
