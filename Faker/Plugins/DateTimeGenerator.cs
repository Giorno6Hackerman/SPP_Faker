using System;
using FakerLibrary;

namespace Plugins
{
    public class DateTimeGenerator : IGenerator
    {
        public object GenerateValue(Random random)
        {
            return new DateTime((random.Next() << 32) | random.Next());
        }

        public Type GetTypeOfValue()
        {
            return typeof(DateTime);
        }
    }
}
