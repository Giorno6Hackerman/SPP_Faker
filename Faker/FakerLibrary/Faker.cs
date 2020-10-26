using System;
using System.Collections.Generic;
using System.Reflection;

namespace FakerLibrary
{
    public class Faker
    {
        private Generator _generator;
        private List<Type> _types;

        public Faker()
        {
            _generator = new Generator();
            _types = new List<Type>();
        }

        public T Create<T>()
        {
            return (T)Create(typeof(T));
        }

        // без конструктора, лишь поля/свойства
        // один конструктор без параметров
        // один конструктор с параметрами
        // нескольок конструкторов
        public static object Create(Type type)
        {
            ConstructorInfo[] constructors = type.GetConstructors();
            List<FieldInfo> fields = new List<FieldInfo>(type.GetFields());
            List<PropertyInfo> properties = new List<PropertyInfo>(type.GetProperties());

            if (constructors.Length == 0)
            {
                return CreateWithoutPublicConstructor(type);
            }

            ConstructorInfo constr = (constructors.Length > 1) ? ChooseConstructor(constructors) : constructors[0];

            
            return null;
        }

        private static ConstructorInfo ChooseConstructor(ConstructorInfo[] constructors)
        {
            int max = 0;
            ConstructorInfo result = constructors[0];
            foreach (var constr in constructors)
            {
                if (constr.GetParameters().Length > max)
                {
                    max = constr.GetParameters().Length;
                    result = constr;
                }
            }
            return result;
        }

        private static object CreateWithoutPublicConstructor(Type type)
        {
            return null;
        }
    }
}
