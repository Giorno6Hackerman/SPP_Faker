using System;
using FakerLibrary;

namespace Plugins
{
    public class CharGenerator : IGenerator
    {
        public object GenerateValue(Random random)
        {
            return (char)random.Next(Char.MaxValue + 1);
        }

        public Type GetTypeOfValue()
        {
            return typeof(Char);
        }
    }
}
