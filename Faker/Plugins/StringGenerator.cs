using System;
using System.Text;
using FakerLibrary;

namespace Plugins
{
    public class StringGenerator : IGenerator
    {
        // без пустой строки ?
        public object GenerateValue(Random random)
        {
            int size = random.Next(1024) + 1;
            byte[] buffer = new byte[size * 2];
            random.NextBytes(buffer);
            return Encoding.UTF8.GetString(buffer);
        }

        public Type GetTypeOfValue()
        {
            return typeof(String);
        }
    }
}
