using Microsoft.AspNetCore.Mvc;
using NetChan.App.Threads.Views;

namespace NetChan.App.Boards
{
    [Route("/")]
    public class BoardController: Controller
    {
        [Route("{shortName}")]
        [HttpGet]
        public IActionResult ShowBoard(string shortName, [FromServices] IBoardService boardService)
        {
            var viewModel = boardService.GetBoardByShortName(shortName);
            return View(viewModel);
        }

        [Route("{shortName}/new")]
        [HttpPost]
        public IActionResult CreateThread(string shortName, [FromForm] CreateThreadFormModel formModel,
            [FromServices] IBoardService boardService)
        {
            boardService.CreateThread(formModel, shortName);
            return RedirectToAction("ShowBoard", new { shortName = shortName });
        }
    }
}