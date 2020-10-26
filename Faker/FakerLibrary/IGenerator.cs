using System;

namespace FakerLibrary
{
    public interface IGenerator
    {
        object GenerateValue(Random random);
        Type GetTypeOfValue();
    }
}
