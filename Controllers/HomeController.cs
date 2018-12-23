using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using NetChan.App.Boards;
using NetChan.App.Boards.Views;
using NetChan.Lib.FormBuilder;
using NetChan.Models;

namespace NetChan.Controllers
{
    [Route("/")]
    public class HomeController : Controller
    {
        [Route("")]
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        [Route("new")]
        public IActionResult CreateBoard([FromForm] CreateBoardFormModel formModel)
        {
            var builder = new FormBuilder<CreateBoardFormModel>(formModel);
            builder.Add(f => f.Title);
            builder.Add(f => f.ShortName);

            return View(builder.GetFormView());
        }

        [HttpPost]
        [Route("new")]
        public IActionResult CreateBoardPost([FromForm] CreateBoardFormModel formModel, 
            [FromServices] IBoardService boardService)
        {
            boardService.CreateBoard(formModel);
            return RedirectToAction("Index");
        }
    }
}
