using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Lab.Quiz.BL.Services.OpenAnswerQuestionService;
using Microsoft.Extensions.Logging;
namespace Teams.Controllers
{
    public class OpenAnswerQuestionController : Controller
    {
        private readonly ILogger<OpenAnswerQuestionController> _logger;
        private IOpenAnswerQuestionService _openAnswerQuestionService;

        public OpenAnswerQuestionController(IOpenAnswerQuestionService openAnswerQuestionService, ILogger<OpenAnswerQuestionController> logger)
        {
            _openAnswerQuestionService = openAnswerQuestionService;
            _logger = logger;
        }

        public async Task<IActionResult> QuestionAsync(Guid id)
        {
            _logger.LogInformation($"Recieved GUID {id}");
            var question = await _openAnswerQuestionService.Get(id);

            if (question == null) return NotFound();
            return View(question);
        }

        public async Task<IActionResult> Answer(string answer, Guid id)
        {
            _logger.LogInformation($"Recieved GUID: {id}|Answer: {answer}");
            var question = await _openAnswerQuestionService.Get(id);
            question.IsAnswer = _openAnswerQuestionService.IsCorrectAnswer(question.Answer, answer);
            return View(question);
        }

    }
}