using System;
using System.Collections.Generic;
using System.Reflection;

namespace FakerLibrary
{
    public class Faker
    {
        private static Generator _generator;
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

            if (constructors.Length == 0)
            {
                return CreateWithoutPublicConstructor(type);
            }

            ConstructorInfo constr = (constructors.Length > 1) ? ChooseConstructor(constructors) : constructors[0];
            if (constr.GetParameters().Length > 0)
            {
                return CreateWithConstructorWithParameters(constr, type);
            }
            else
            {
                return CreateWithConstructorWithoutParameters(constr, type);
            }
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
            
            object result = Activator.CreateInstance(type);
            return FillFieldsAndProperties(result, type);
        }

        private static object FillFieldsAndProperties(object obj, Type type)
        {
            FieldInfo[] fields = type.GetFields();
            PropertyInfo[] properties = type.GetProperties();

            foreach (var field in fields)
            {
                field.SetValue(obj, Generator.GetGeneratedValue(field.FieldType));
            }

            foreach (var property in properties)
            {
                property.SetValue(obj, Generator.GetGeneratedValue(property.PropertyType));
            }
            return obj;
        }

        private static object CreateWithConstructorWithParameters(ConstructorInfo constructor, Type type)
        {
            object[] values = new object[constructor.GetParameters().Length];
            ParameterInfo[] parameters = constructor.GetParameters();

            for (int i = 0; i < values.Length; i++)
            {
                values[i] = Generator.GetGeneratedValue(parameters[i].ParameterType);
            }

            object result = constructor.Invoke(values);
            return FillFieldsAndProperties(result, type);
        }

        private static object CreateWithConstructorWithoutParameters(ConstructorInfo constructor, Type type)
        {
            object result = constructor.Invoke(null);
            return FillFieldsAndProperties(result, type);
        }
    }
}
