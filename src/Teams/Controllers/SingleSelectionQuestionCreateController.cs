using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Teams.Data.SingleSelectionQuestionRepos;
using Teams.Domain;
using Teams.Models;

namespace Teams.Controllers
{
    public class SingleSelectionQuestionCreateController : Controller
    {
        readonly private ISingleSelectionQuestionRepository _singleRepository;
        private readonly ILogger<SingleSelectionQuestionCreateController> _logger;
        public SingleSelectionQuestionCreateController(ISingleSelectionQuestionRepository singleRepository, 
            ILogger<SingleSelectionQuestionCreateController> logger)
        {
            _singleRepository = singleRepository;
            _logger = logger;
        }

        [HttpGet]
        public IActionResult Create()
        {
            _logger.LogInformation("");
            return View();
        }

        [HttpPost]
        public IActionResult Create(SingleSelectionQuestionModel modelForView, IList<string> textOfAnswers, string radioButtonValue)
        {
            _logger.LogInformation("");

            if (modelForView == null)
            return BadRequest("Model for view is empty.");
            
            var question = new SingleSelectionQuestion(modelForView.Question, textOfAnswers, radioButtonValue);
            _singleRepository.AddQuestion(question);
            return RedirectToAction("Index", "Home");
        }

        [HttpGet]
        [Route("[Controller]/Edit")]
        public async Task<IActionResult> EditQuestionById(Guid id)
        {
            _logger.LogInformation($"Recieved GUID: {id}");

            var question = await _singleRepository.GetAsync(id);
            if (question == null)
            return NotFound();

            var modelForView = new SingleSelectionQuestionModel
            {
                Question = question.Text,
                Id = question.Id
            };

            modelForView.Answers = question.Options
                .Select(o => o.Text)
                .ToList();
            modelForView.IndexOfTrueAnswer = question.Options
                .Select((item, i) => new {
                    Item = item,
                    Pos = i
                })
                .FirstOrDefault(o => o.Item.IsAnswer == true).Pos;

            return View(modelForView);
        }

        [HttpPut]
        [Route("[Controller]/Edit")]
        public async Task<IActionResult> EditQuestionById(SingleSelectionQuestionModel modelForView, IList<string> textOfAnswers, string radioButtonValue)
        {
            _logger.LogInformation($"GUID: {modelForView.Id}|Answers: {String.Join(", ", textOfAnswers)}" +
                $"|radioButtonValue: {radioButtonValue}");

            if (modelForView == null)
            return BadRequest("Model for view is empty.");

            var question = await _singleRepository.GetAsync(modelForView.Id);
            if (question == null)
            return RedirectToAction("Index", "Home");

            int.TryParse(radioButtonValue, out var radioButtonIntValue);
            var newOptions = new List<SingleSelectionQuestionOption>();
            for (int i = 0; i < textOfAnswers.Count(); i++)
            {
                var isAnswer = i == radioButtonIntValue;
                var option = new SingleSelectionQuestionOption(textOfAnswers[i], isAnswer);
                newOptions.Add(option);
            }
            _singleRepository.DeleteQuestionOptionsInDB(question);
            question.Update(modelForView.Question, newOptions);
            _singleRepository.UpdateQuestion(question);
            
            return RedirectToAction("Index", "Home");
        }
    }
}
