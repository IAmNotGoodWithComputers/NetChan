using System;
using System.Collections.Immutable;
using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace NetChan.Lib.FormBuilder
{
    public class FormView<TEntity>
    {
        public IImmutableList<FormField> Fields;
        public TEntity FormModel;

        public object GetValue(string FieldName)
        {
            return FormModel.GetType().GetProperty(FieldName).GetValue(FormModel, null);
        }

        public IHtmlContent RenderForm()
        {
            var tagBuilder = new TagBuilder("div");
            foreach (var viewField in Fields)
            {
                IHtmlContent fieldTag;
                switch (viewField.FieldType)
                {
                    case FieldTypes.File:
                        fieldTag = RenderFileField(viewField);
                        break;
                    case FieldTypes.Password:
                        fieldTag = RenderPasswordField(viewField);
                        break;
                    case FieldTypes.Select:
                        fieldTag = RenderSelectField(viewField);
                        break;
                    case FieldTypes.Text:
                        fieldTag = RenderTextField(viewField);
                        break;
                    case FieldTypes.TextArea:
                        fieldTag = RenderTextAreaField(viewField);
                        break;
                    default:
                        throw new ArgumentOutOfRangeException();
                }

                if (fieldTag != null)
                {
                    tagBuilder.InnerHtml.AppendHtml(RenderFormField(viewField, fieldTag));
                }
            }

            return tagBuilder;
        }

        protected IHtmlContent RenderFormField(FormField viewField, IHtmlContent inputField)
        {
            var divTag = new TagBuilder("div");
            divTag.AddCssClass("form-group");
            
            var labelTag = new TagBuilder("label");
            labelTag.Attributes["for"] = viewField.fieldName;
            labelTag.InnerHtml.Append(viewField.fieldName);
            if (viewField.Required)
            {
                var requiredTag = new TagBuilder("span");
                requiredTag.Attributes["style"] = "color: red";
                requiredTag.InnerHtml.Append("*");
                labelTag.InnerHtml.AppendHtml(requiredTag);
            }

            divTag.InnerHtml.AppendHtml(labelTag);
            divTag.InnerHtml.AppendHtml(inputField);

            if (!string.IsNullOrEmpty(viewField.HelpText))
            {
                var helptextTag = new TagBuilder("small");
                helptextTag.Attributes["class"] = "form-text text-muted";
                helptextTag.InnerHtml.Append(viewField.HelpText);
                divTag.InnerHtml.AppendHtml(helptextTag);
            }
            
            return divTag;
        }

        private IHtmlContent RenderTextAreaField(FormField viewField)
        {
            var textAreaTag = new TagBuilder("textarea");
            textAreaTag.AddCssClass("form-control");
            
            textAreaTag.Attributes["name"] = viewField.fieldName;
            textAreaTag.Attributes["id"] = viewField.fieldName;
            
            var value = GetValue(viewField.fieldName);
            if (value != null)
            {
                textAreaTag.InnerHtml.Append(value.ToString());
            }

            return textAreaTag;
        }

        private IHtmlContent RenderTextField(FormField viewField)
        {
            var inputTag = new TagBuilder("input");
            inputTag.AddCssClass("form-control");
            
            inputTag.Attributes["type"] = "text";
            inputTag.Attributes["name"] = viewField.fieldName;
            inputTag.Attributes["id"] = viewField.fieldName;
            
            var value = GetValue(viewField.fieldName);
            if (value != null)
            {
                inputTag.Attributes["value"] = value.ToString();
            }

            return inputTag; 
        }

        private static IHtmlContent RenderSelectField(FormField viewField)
        {
            var tagBuilder = new TagBuilder("input");
            tagBuilder.Attributes["type"] = "password";
            tagBuilder.Attributes["name"] = viewField.fieldName;
            tagBuilder.Attributes["id"] = viewField.fieldName;
            return tagBuilder;
        }

        protected IHtmlContent RenderPasswordField(FormField viewField)
        {
            var inputTag = new TagBuilder("input");
            inputTag.AddCssClass("form-control");
            
            inputTag.Attributes["type"] = "password";
            inputTag.Attributes["name"] = viewField.fieldName;
            inputTag.Attributes["id"] = viewField.fieldName;
            
            var value = GetValue(viewField.fieldName);
            if (value != null)
            {
                inputTag.Attributes["value"] = value.ToString();
            }

            return inputTag; 
        }

        protected IHtmlContent RenderFileField(FormField viewField)
        {
            var inputTag = new TagBuilder("input");
            inputTag.AddCssClass("form-control");
            
            inputTag.Attributes["type"] = "file";
            inputTag.Attributes["name"] = viewField.fieldName;
            inputTag.Attributes["id"] = viewField.fieldName;
            
            return inputTag; 
        }
    }
}