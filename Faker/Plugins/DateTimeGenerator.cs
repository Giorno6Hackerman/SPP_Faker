using System;
using FakerLibrary;

namespace Plugins
{
    public class DateTimeGenerator : IGenerator
    {
        public object GenerateValue(Random random)
        {
            return new DateTime((random.Next(1 << 30) << 34) | (random.Next(1 << 30) << 4) | random.Next(1 << 4));
        }

        public Type GetTypeOfValue()
        {
            return typeof(DateTime);
        }
    }
}
