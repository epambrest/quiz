using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Teams.Data;
using Teams.Data.Repositories;
using Teams.Domain;
using Teams.Models;

namespace Teams.Controllers
{
    public class MultipleAnswerQuestionController : Controller
    {
        private readonly IMultipleAnswerQuestionRepository _questionRepository;
        private readonly ILogger<MultipleAnswerQuestionController> _logger;

        public MultipleAnswerQuestionController(IMultipleAnswerQuestionRepository questionRepository,
            ILogger<MultipleAnswerQuestionController> logger)
        {
            _questionRepository = questionRepository;
            _logger = logger;
        }
        [HttpGet]
        public IActionResult Index(Guid id)
        {
            _logger.LogInformation($"Recieved id: {id}");
            var question = new MultipleAnswerQuestionViewModel()
            {
                SourceQuestion = _questionRepository.PickById(id)
            };
            return View("MultipleAnswerQuestionForm", question);
        }
        public IActionResult MultipleAnswerQuestionForm(string id, int[] answers)
        {
            _logger.LogInformation($"Recieved id: {id}|Chosen options: {String.Join(", ", answers)}");
            var question = new MultipleAnswerQuestionViewModel()
            {
                SourceQuestion = _questionRepository.PickById(new Guid(id)),
                ChosenOptions = answers
            };
            return View(question);
        }

        [Route("[Controller]/[Action]/{id?}")]
        public IActionResult EditMultipleAnswerQuestion(Guid id)
        {
            _logger.LogInformation($"Recieved GUID: {id}");
            var question = new MultipleAnswerQuestionViewModel()
            {
                SourceQuestion = _questionRepository.PickById(id),
            };
            return View(question);
        }
        [HttpGet]
        public IActionResult ShowMultipleAnswerQuestionForm()
        {
            _logger.LogInformation("");
            return View("AddMultipleAnswerQuestion");
        }

        [HttpPost]
        public IActionResult AddMultipleAnswerQuestion([FromBody] MultipleQuestionAddModel multipleAnswersQuestionDTO)
        {
            IEnumerable<string> answers = multipleAnswersQuestionDTO.QuestionAnswers.Select(a => a.AnswersText);
            _logger.LogInformation($"QuestionText: {multipleAnswersQuestionDTO.QuestionText}|Answers: {String.Join(", ", answers)}");

            var allAnswers = multipleAnswersQuestionDTO.QuestionAnswers
                 .Select(x => new MultipleAnswerQuestionOption(x.AnswersText, x.IsRightAnswer))
                 .ToList();

            _questionRepository.AddQuestion(new MultipleAnswerQuestion(multipleAnswersQuestionDTO.QuestionText, allAnswers));

            return RedirectToAction("Index", "Home");

        }
        [HttpPut]
        public IActionResult EditMultipleAnswerQuestion([FromBody] MultipleQuestionEditModel multipleAnswersQuestionDTO)
        {
            IEnumerable<string> answers = multipleAnswersQuestionDTO.QuestionAnswers.Select(a => a.AnswersText);
            _logger.LogInformation($"QuestionText: {multipleAnswersQuestionDTO.QuestionText}|Answers: {String.Join(", ", answers)}");

            var allAnswers = multipleAnswersQuestionDTO.QuestionAnswers
                .Select(x => new MultipleAnswerQuestionOption(x.AnswersText, x.IsRightAnswer))
                .ToList();

            MultipleAnswerQuestion question = _questionRepository.PickById(multipleAnswersQuestionDTO.Id);

            _questionRepository.DeleteQuestionOptionsInDB(question);
            question.EditQuestion(multipleAnswersQuestionDTO.QuestionText, allAnswers);
            _questionRepository.UpdateQuestion(question);

            return RedirectToAction("Index", "Home");
        }
    }
}
