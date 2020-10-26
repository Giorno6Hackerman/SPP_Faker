using System;

namespace FakerLibrary
{
    public class Faker
    {
        public delegate T Generate<T>();

        public Faker()
        { 
        
        }

        public static Generate<T> GetGenerator<T>()
        {
            string typeName = typeof(T).Name;
            if (typeName.StartsWith("List<"))
            {
                string subType = typeName.Substring(5, typeName.IndexOf(">") - 5);
            }
            switch (typeName)
            {
                case "Boolean":
                    Generate<bool> gen = ListGenerator.GenerateBoolean;
                    break;
                case "Byte":
                case "SByte":
                case "Char":
                case "Int16":
                case "UInt16":
                case "Int32":
                case "UInt32":
                case "Int64":
                case "UInt64":
                case "Single":
                case "Double":
                case "Decimal":
                case "DateTime":
                case "String":
                default:
                    break;
            }
            return null;
        }
    }
}
