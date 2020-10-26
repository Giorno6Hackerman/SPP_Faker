using System;
using FakerLibrary;

namespace Plugins
{
    public class UInt16Generator : IGenerator
    {
        public object GenerateValue(Random random)
        {
            return (UInt16)random.Next(UInt16.MinValue, UInt16.MaxValue);
        }

        public Type GetTypeOfValue()
        {
            return typeof(UInt16);
        }
    }
}
