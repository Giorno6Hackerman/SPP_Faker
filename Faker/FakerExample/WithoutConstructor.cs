using System;
using System.Collections.Generic;

namespace FakerExample
{
    public class WithoutConstructor
    {
        public bool BoolProp { get; set; }
        public byte ByteProp { get; set; }
        public char CharProp { get; set; }
        public int IntProp { get; set; }
        public DateTime DateTimeProp { get; set; }
        public List<string> ListProp;

        public string GetInfo()
        {
            string result = "";
            foreach (var str in ListProp)
            {
                result += str + "\n";
            }
            return $"BoolProp: {BoolProp}, ByteProp: {ByteProp}, CharProp: {CharProp}, IntProp: {IntProp}\n" + 
                   $"DateTimeProp: {DateTimeProp}, ListProp: {result}";
        }
    }
}
