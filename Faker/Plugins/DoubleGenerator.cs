using System;
using FakerLibrary;

namespace Plugins
{
    public class DoubleGenerator : IGenerator
    {
        public object GenerateValue(Random random)
        {
            var buffer = new byte[8];
            random.NextBytes(buffer);
            return BitConverter.ToDouble(buffer, 0);
        }

        public Type GetTypeOfValue()
        {
            return typeof(Double);
        }
    }
}
