using System;

namespace NetChan.Lib.FormBuilder.Attributes
{
    public class PlaceHolder: Attribute
    {
        public string Value;

        public PlaceHolder(string value)
        {
            Value = value;
        }
    }
}