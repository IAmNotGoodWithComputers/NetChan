using NetChan.Lib.FormBuilder;
using NetChan.Lib.FormBuilder.Attributes;

namespace NetChan.App.Boards.Views
{
    public class CreateBoardFormModel
    {
        [FieldType(FieldTypes.Text)]
        public string Title { get; set; }
        [FieldType(FieldTypes.Text)]
        public string ShortName { get; set; }
    }
}