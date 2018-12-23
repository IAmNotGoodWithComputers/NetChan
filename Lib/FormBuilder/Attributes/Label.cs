using System;

namespace NetChan.Lib.FormBuilder.Attributes
{
    [AttributeUsage(AttributeTargets.Property)]
    public class Label: Attribute
    {
        public readonly string Value;

        public Label(string value)
        {
            Value = value;
        }
    }
}