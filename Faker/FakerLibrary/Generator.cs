﻿using System;
using System.Collections.Generic;
using System.Reflection;

namespace FakerLibrary
{
    public class Generator
    {
        private string path = "C:\\5 sem\\SPP\\Labs\\Lab_2\\Faker\\Plugins\\bin\\Debug\\netcoreapp3.1\\Plugins.dll";
        public delegate object Generate(Random random);
        private Dictionary<Type, Generate> _generators;
        private Random _random;

        public Generator()
        {
            _generators = new Dictionary<Type, Generate>();
            _random = new Random();
            LoadPlugins();
        }

        // подгрузить остальные плагины
        private void LoadPlugins()
        {
            Assembly asm = Assembly.LoadFrom(path);
            foreach (Type type in asm.GetTypes())
            {
                var tmp = asm.CreateInstance(type.FullName);
                var gen = asm.CreateInstance(type.FullName) as IGenerator;
                //object gen = Activator.CreateInstance(type);
                _generators.Add(gen.GetTypeOfValue(), gen.GenerateValue);
            }
        }

        // выдавать нужный генератор по типу, в том числе лист
        // обрабатка дто и типов без генератора
        public object GetGeneratedValue(Type type)
        {
            Generate gen;
            if (_generators.TryGetValue(type, out gen))
            {
                return gen(_random);
            }

            if (type.IsGenericType && type.GetInterface("IList") != null)
            {
                ListGenerator listGen = new ListGenerator();
                return listGen.GenerateList(this, _random, type.GenericTypeArguments[0]);
            }

            if (type.IsClass && !type.IsGenericType && !type.IsAbstract && !type.IsArray)
            {
                return FakerSingleton.GetInstance().Create(type);
            }
            return null;
        }
    }
}
