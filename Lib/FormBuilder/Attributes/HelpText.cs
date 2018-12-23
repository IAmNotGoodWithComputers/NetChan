using System;

namespace NetChan.Lib.FormBuilder.Attributes
{
    [AttributeUsage(AttributeTargets.Property)]
    public class HelpText: Attribute
    {
        public readonly string Value;

        public HelpText(string value)
        {
            Value = value;
        }
    }
}