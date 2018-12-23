using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using NetChan.Lib.FormBuilder;

namespace NetChan.App.Threads
{
    public class CreateThreadViewComponent: ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var builder = new FormBuilder<CreateThreadFormModel>(new CreateThreadFormModel());
            builder.Add(f => f.Username);
            builder.Add(f => f.Title);
            builder.Add(f => f.Content);
            builder.Add(f => f.Attachments);

            return View(builder.GetFormView());
        }
    }
}