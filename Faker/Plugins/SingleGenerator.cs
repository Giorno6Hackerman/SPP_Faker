using System;
using FakerLibrary;

namespace Plugins
{
    public class SingleGenerator : IGenerator
    {
        public object GenerateValue(Random random)
        {
            var buffer = new byte[4];
            random.NextBytes(buffer);
            return BitConverter.ToSingle(buffer, 0);
        }

        public Type GetTypeOfValue()
        {
            return typeof(Single);
        }
    }
}
