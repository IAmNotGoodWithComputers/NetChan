using Microsoft.AspNetCore.Mvc;

namespace NetChan.App.Threads
{
    [Route("/")]
    public class ThreadController: Controller
    {
        [Route("{boardShortName}/{threadId}")]
        public IActionResult ShowThread(string boardShortName, string threadId)
        {
            return View();
        }
    }
}