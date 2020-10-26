using FakerLibrary;
using System;

namespace Plugins
{
    public class BooleanGenerator : IGenerator
    {
        public object GenerateValue(Random random)
        {
            return random.Next(2) == 1;
        }

        public Type GetTypeOfValue()
        {
            return typeof(Boolean);
        }
    }
}
