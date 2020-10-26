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
        public object Create(Type type)
        {
            if (_types.Contains(type))
            {
                return null;
            }

            _types.Add(type);
            object result;
            ConstructorInfo[] constructors = type.GetConstructors();

            if (constructors.Length == 0)
            {
                result = CreateWithoutPublicConstructor(type);
            }
            else
            {
                ConstructorInfo constr = (constructors.Length > 1) ? ChooseConstructor(constructors) : constructors[0];
                if (constr.GetParameters().Length > 0)
                {
                    result = CreateWithConstructorWithParameters(constr, type);
                }
                else
                {
                    result = CreateWithConstructorWithoutParameters(constr, type);
                }
            }

            _types.Remove(type);
            return result;
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

        private object CreateWithoutPublicConstructor(Type type)
        {
            
            object result = Activator.CreateInstance(type);
            return FillFieldsAndProperties(result, type);
        }

        private object FillFieldsAndProperties(object obj, Type type)
        {
            FieldInfo[] fields = type.GetFields();
            PropertyInfo[] properties = type.GetProperties();

            foreach (var field in fields)
            {
                field.SetValue(obj, _generator.GetGeneratedValue(field.FieldType));
            }

            foreach (var property in properties)
            {
                property.SetValue(obj, _generator.GetGeneratedValue(property.PropertyType));
            }
            return obj;
        }

        private object CreateWithConstructorWithParameters(ConstructorInfo constructor, Type type)
        {
            object[] values = new object[constructor.GetParameters().Length];
            ParameterInfo[] parameters = constructor.GetParameters();

            for (int i = 0; i < values.Length; i++)
            {
                values[i] = _generator.GetGeneratedValue(parameters[i].ParameterType);
            }

            object result = constructor.Invoke(values);
            return FillFieldsAndProperties(result, type);
        }

        private object CreateWithConstructorWithoutParameters(ConstructorInfo constructor, Type type)
        {
            object result = constructor.Invoke(null);
            return FillFieldsAndProperties(result, type);
        }
    }
}
