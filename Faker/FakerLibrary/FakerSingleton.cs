using System;
using System.Collections.Generic;
using System.Text;

namespace FakerLibrary
{
    public static class FakerSingleton
    {
        private static Faker _instance;

        public static Faker GetInstance()
        {
            if (_instance == null)
            {
                _instance = new Faker();
            }
            return _instance;
        }
    }
}
