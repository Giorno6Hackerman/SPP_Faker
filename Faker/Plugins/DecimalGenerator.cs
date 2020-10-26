using System;
using FakerLibrary;

namespace Plugins
{
    public class DecimalGenerator : IGenerator
    {
        public object GenerateValue(Random random)
        {
            return new decimal(random.Next(), random.Next(), random.Next(), random.Next(2) == 1, (byte)random.Next(29));
        }

        public Type GetTypeOfValue()
        {
            return typeof(Decimal);
        }
    }
}
