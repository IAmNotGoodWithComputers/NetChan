using System;

namespace NetChan.Lib.FormBuilder.Attributes
{
    [AttributeUsage(AttributeTargets.Property)]
    public class CssClass: Attribute
    {
        public readonly string Value;

        public CssClass(string value)
        {
            Value = value;
        }
    }
}