using System;
using System.Collections.Generic;

namespace FakerExample
{
    public class ManyConstructors
    {
        public ManyConstructors()
        { 
        
        }

        public ManyConstructors(Int16 int16)
        {
            _int16Prop = int16;
        }

        public ManyConstructors(Int16 int16, Single single)
        {
            _int16Prop = int16;
            _singleProp = single;
        }

        private Int16 _int16Prop;
        private Single _singleProp;
        public Int64 Int64Prop { get; set; }
        public List<int> ListProp { get; set; }
        public OneConstructor OneProp;

        public string GetInfo()
        {
            string result = "";
            foreach (var str in ListProp)
            {
                result += str + "\n";
            }
            return $"**_int16Prop: {_int16Prop}, _singleProp: {_singleProp}, Int64Prop: {Int64Prop}, \nListProp: {result}, " 
                    + OneProp.GetInfo() + "**";
        }
    }
}
