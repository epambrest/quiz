using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Teams.Data;
using Teams.Data.Repositories;
using Teams.Domain;
using Teams.Models;

namespace Teams.Controllers
{
    public class MultipleAnswerQuestionController : Controller
    {
        private IApplicationDbContext _db;
        public MultipleAnswerQuestionController(IMultipleAnswerQuestionRepository questionRepository, IApplicationDbContext db)
        {
            this.questionRepository = questionRepository;
            _db = db;
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

        public IActionResult EditMultipleAnswerQuestion(Guid id)
        {
            var question = new MultipleAnswerQuestionViewModel()
            {
                SourceQuestion = questionRepository.PickById(id),
            };
            return View(question);
        }

        public IActionResult AddMultipleAnswerQuestion()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddMultipleAnswerQuestion([FromBody] MultipleQuestionAddModel fromAjax)
        {
            List<MultipleAnswerQuestionOption> allAnswers = new List<MultipleAnswerQuestionOption>();
            allAnswers = fromAjax.TextArray.Select((value, index) => new MultipleAnswerQuestionOption(value, fromAjax.CheckboxValueArray[index])).ToList();

            questionRepository.AddQuestion(new MultipleAnswerQuestion(fromAjax.QuestionText, allAnswers));
            _db.SaveChanges();

            return RedirectToAction("Index", "Home");

        }
        [HttpPost]
        public IActionResult EditMultipleAnswerQuestion([FromBody] MultipleQuestionEditModel fromAjax)
        {
            List<MultipleAnswerQuestionOption> allAnswers = new List<MultipleAnswerQuestionOption>();
            allAnswers = fromAjax.TextArray.Select((value, index) => new MultipleAnswerQuestionOption(value, fromAjax.CheckboxValueArray[index])).ToList();

            MultipleAnswerQuestion question = questionRepository.PickById(fromAjax.id);

            questionRepository.DeleteQuestionOptionsIn_DB(question);
            question.EditQuestion(fromAjax.QuestionText, allAnswers);
            questionRepository.UpdateQuestion(question);
            _db.SaveChanges();

            return RedirectToAction("Index", "Home");
        }
    }
}
