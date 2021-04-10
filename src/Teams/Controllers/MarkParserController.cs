using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Teams.Extensions;
using Westwind.AspNetCore.Markdown;

namespace Teams.Controllers
{
    public class MarkParserController : Controller
    {
        private readonly ILogger<MarkParserController> _logger;

        public MarkParserController(ILogger<MarkParserController> logger)
        {
            _logger = logger;
        }

        [HttpPost]
        public JsonResult GetMarkdownQuestion(string question)
        {
            _logger.LogInformation();
            string html = Markdown.Parse(question);
            return Json(html);
        }
    }
}
