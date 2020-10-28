using System;

namespace FakerExample
{
    public class OneConstructor
    {
        public OneConstructor()
        { 
        
        }

        public UInt16 UInt16Prop { get; set; }
        public UInt64 UInt64Prop { get; set; }
        public decimal DecimalProp;
        public string StringProp;

        public string GetInfo()
        {
            return $"UInt16Prop: {UInt16Prop}, UInt64Prop: {UInt64Prop}, DecimalProp: {DecimalProp}" + 
                   $"StringProp: {StringProp}";
        }
    }
}
