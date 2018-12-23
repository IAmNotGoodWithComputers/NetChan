using System.Collections.Generic;
using Microsoft.AspNetCore.Http;
using NetChan.Lib.FormBuilder;
using NetChan.Lib.FormBuilder.Attributes;

namespace NetChan.App.Threads.Views
{
    public class CreateThreadFormModel
    {
        [FieldType(FieldTypes.Text)]
        [HelpText("You don't need to provide a username. If you don't, you will appear as 'Anonymous'")]
        public string Username { get; set; }
        
        [FieldType(FieldTypes.Text)]
        [Required]
        public string Title { get; set; }
        
        [FieldType(FieldTypes.TextArea)]
        [Required]
        public string Content { get; set; }
        
        [FieldType(FieldTypes.File)]
        [Required]
        public List<IFormFile> Attachments { get; set; }

    }
}