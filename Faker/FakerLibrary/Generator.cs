using System;
using System.Collections.Generic;
using System.Reflection;

namespace FakerLibrary
{
    public class Generator
    {
        private string path = "Plugins\\bin\\Debug\\netcoreapp3.1\\Plugins.dll";
        public delegate object Generate(Random random);
        private static Dictionary<Type, Generate> _generators;
        private static Random _random;

        public Generator()
        {
            _generators = new Dictionary<Type, Generate>();
            _random = new Random();
            LoadPlugins();
        }

        // подгрузить остальные плагины
        private void LoadPlugins()
        {
            Assembly asm = Assembly.Load(path);

        }

        // выдавать нужный генератор по типу, в том числе лист
        // обрабатка дто и типов без генератора
        public static object GetGeneratedValue(Type type)
        {
            Generate gen;
            if (_generators.TryGetValue(type, out gen))
            {
                return gen(_random);
            }

            if (type.IsGenericType && type.GetInterface("IList") != null)
            {
                return ListGenerator.GenerateList(_random, type.GenericTypeArguments[0]);
            }

            if (type.IsClass && !type.IsGenericType && !type.IsAbstract && !type.IsArray)
            {
                return Faker.Create(type);
            }
            return null;
        }
    }
}
