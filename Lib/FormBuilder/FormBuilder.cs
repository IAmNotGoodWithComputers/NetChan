using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq.Expressions;
using System.Reflection;
using NetChan.Lib.FormBuilder.Attributes;

namespace NetChan.Lib.FormBuilder
{
    public class FormBuilder<TEntity>
    {
        private readonly TEntity formModel;
        private List<FormField> fields { get; set; }

        public FormBuilder(TEntity formModel)
        {
            fields = new List<FormField>();
            this.formModel = formModel;
        }

        public FormField Add(Expression<Func<TEntity, object>> fn)
        {
            var propertyInfo = ((MemberExpression)fn.Body).Member as PropertyInfo;

            if (propertyInfo == null)
            {
                return null;
            }

            var field = CreateFieldByPropertyInfo(propertyInfo);
            fields.Add(field);
            return field;
        }
        
        public TEntity GetFormModel()
        {
            return formModel;
        }

        public FormView<TEntity> GetFormView()
        {
            var view = new FormView<TEntity>();
            view.Fields = fields.ToImmutableList();
            view.FormModel = formModel;
            return view;
        }

        private FormField CreateFieldByPropertyInfo(PropertyInfo propertyInfo)
        {
            var field = new FormField(propertyInfo.Name);
            
            var cssClass = propertyInfo.GetCustomAttribute<CssClass>();
            var fieldType = propertyInfo.GetCustomAttribute<FieldType>();
            var helpText = propertyInfo.GetCustomAttribute<HelpText>();
            var label = propertyInfo.GetCustomAttribute<Label>();
            var placeHolder = propertyInfo.GetCustomAttribute<PlaceHolder>();
            var required = propertyInfo.GetCustomAttribute<Required>();

            field.SetCssClass(cssClass?.Value);
            field.SetFieldType(fieldType?.Value ?? FieldTypes.Text);
            field.SetHelpText(helpText?.Value);
            field.SetLabel(label?.Value ?? field.fieldName);
            field.SetPlaceHolder(placeHolder?.Value);
            field.SetRequired(required != null);

            return field;
        }
    }
}