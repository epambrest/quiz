using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Teams.Data;
using Teams.Data.SingleSelectionQuestionRepos;
using Teams.Domain;
using Teams.Models;

namespace Teams.Controllers
{
    public class SingleSelectionQuestionCreateController : Controller
    {
        private ISingleSelectionQuestionRepository _singleRepository { get; set; }
        public SingleSelectionQuestionCreateController(ISingleSelectionQuestionRepository singleRepository)
        {
            _singleRepository = singleRepository;
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(SingleSelectionQuestionModel modelForView, List<string> textOfAnswers, string radioButtonValue)
        {
            SingleSelectionQuestion question = new SingleSelectionQuestion(modelForView.Question, textOfAnswers, radioButtonValue);
            _singleRepository.AddQuestion(question);
            return RedirectToAction("Index", "Home");
        }

        public IActionResult Edit(Guid id)
        {
            var question = _singleRepository.Get(id);
            if (question != null)
            {
                SingleSelectionQuestionModel modelForView = new SingleSelectionQuestionModel
                {
                    Question = question.Text,
                    Id = question.Id
                };

                modelForView.Answers = new List<string>();
                modelForView.Answers = question.Options.Select(o => o.Text).ToList();
                modelForView.IndexOfTrueAnswer = question.Options.Select((item, i) => new {
                    Item = item,
                    Pos = i }).Where(o => o.Item.IsAnswer == true).First().Pos;

                return View(modelForView);
            }
            return NotFound();
        }

        [HttpPost]
        public IActionResult Edit(SingleSelectionQuestionModel modelForView, List<string> textOfAnswers, string radioButtonValue)
        {
            var question = _singleRepository.Get(modelForView.Id);
            if (question != null)
            {
                List<SingleSelectionQuestionOption> newOptions = new List<SingleSelectionQuestionOption>();
                for (int i = 0; i < textOfAnswers.Count(); i++)
                {
                    if (i == Convert.ToInt32(radioButtonValue))
                    {
                        SingleSelectionQuestionOption option = new SingleSelectionQuestionOption(textOfAnswers[i], true);
                        newOptions.Add(option);
                    }
                    else
                    {
                        SingleSelectionQuestionOption option = new SingleSelectionQuestionOption(textOfAnswers[i], false);
                        newOptions.Add(option);
                    }
                }
                _singleRepository.DeleteQuestionOptionsIn_DB(question);
                question.Update(modelForView.Question, newOptions);
                _singleRepository.UpdateQuestion(question);
            }
            return RedirectToAction("Index", "Home");
        }
    }
}
