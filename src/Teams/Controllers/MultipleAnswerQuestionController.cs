using Microsoft.AspNetCore.Mvc;
using System;
using Teams.Data.Repositories;
using Teams.Models;

namespace Teams.Controllers
{
    public class MultipleAnswerQuestionController : Controller
    {
        public MultipleAnswerQuestionController(IMultipleAnswerQuestionRepository questionRepository)
        {
            this.questionRepository = questionRepository;
        }
        private readonly IMultipleAnswerQuestionRepository questionRepository;
        [HttpGet]
        public IActionResult Index(Guid id)
        {
            var question = new MultipleAnswerQuestionViewModel()
            {
                SourceQuestion = questionRepository.PickById(id)
            };
            return View("MultipleAnswerQuestionForm", question);
        }
        public IActionResult MultipleAnswerQuestionForm(string id, int[] answers)
        {
            var question = new MultipleAnswerQuestionViewModel()
            {
                SourceQuestion = questionRepository.PickById(new Guid(id)),
                ChosenOptions = answers
            };
            return View(question);
        }
    }
}
