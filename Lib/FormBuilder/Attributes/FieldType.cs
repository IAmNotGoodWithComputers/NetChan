using System;

namespace NetChan.Lib.FormBuilder.Attributes
{
    [AttributeUsage(AttributeTargets.Property)]
    public class FieldType: Attribute
    {
        public readonly FieldTypes Value;

        public FieldType(FieldTypes value)
        {
            Value = value;
        }
    }
}