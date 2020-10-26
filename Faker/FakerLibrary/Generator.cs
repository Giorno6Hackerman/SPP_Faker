using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace FakerLibrary
{
    public class Generator
    {
        private string path = "Plugins\\bin\\Debug\\netcoreapp3.1\\Plugins.dll";
        public delegate object Generate();
        private static Dictionary<Type, Generate> _generators;

        public Generator()
        {
            _generators = new Dictionary<Type, Generate>();
            LoadPlugins();
        }

        // подгрузить остальные плагины
        private void LoadPlugins()
        {
            Assembly asm = Assembly.Load(path);

        }

        // выдавать нужный генератор по типу, в том числе лист
        // обрабатка дто и типов без генератора
        public static object GetGenerator(Type type)
        {
            Generate gen;
            if (_generators.TryGetValue(type, out gen))
            {
                return gen();
            }

            if (type.IsGenericType)
            {

            }
            return null;
        }
    }
}
