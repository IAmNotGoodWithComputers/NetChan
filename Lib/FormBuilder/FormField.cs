namespace NetChan.Lib.FormBuilder
{
    public enum FieldTypes: ushort
    {
        Text = 10,
        TextArea = 20,
        Password = 30,
        Select = 40,
        File = 50,
    }
    
    public class FormField
    {
        public readonly string fieldName;

        public FieldTypes FieldType;
        public string Label;
        public bool Required;
        public string ErrorMessage;
        public string HelpText;
        public string CssClass;
        public string PlaceHolder;
        
        public string ViewLabel => string.IsNullOrEmpty(Label) ? fieldName : Label;

        public FormField(string fieldName)
        {
            this.fieldName = fieldName;
        }

        public FormField SetLabel(string label)
        {
            Label = label;
            return this;
        }

        public FormField SetRequired(bool required)
        {
            Required = required;
            return this;
        }

        public FormField SetErrorMessage(string errorMessage)
        {
            ErrorMessage = errorMessage;
            return this;
        }

        public FormField SetHelpText(string helpText)
        {
            HelpText = helpText;
            return this;
        }

        public FormField SetCssClass(string cssClass)
        {
            CssClass = cssClass;
            return this;
        }

        public FormField SetPlaceHolder(string placeHolder)
        {
            PlaceHolder = placeHolder;
            return this;
        }

        public FormField SetFieldType(FieldTypes fieldType)
        {
            FieldType = fieldType;
            return this;
        }
    }
}