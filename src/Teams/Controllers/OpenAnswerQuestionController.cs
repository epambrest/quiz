using Microsoft.AspNetCore.Mvc;
using System;
using Teams.Data.OpenAnswerQuestionRepos;
using Teams.Models;

namespace Teams.Controllers
{
    public class OpenAnswerQuestionController : Controller
    {

        public IOpenAnswerQuestionRepository context;

        public OpenAnswerQuestionController(IOpenAnswerQuestionRepository context)
        {
            this.context = context;
        }

        public IActionResult Question(Guid id)
        {

            var question = context.Get(id);

            if (question == null) return NotFound();

            OpenAnswerQuestionModel ivm = new OpenAnswerQuestionModel
            {
                Id = id,
                Question = question.QuestionText
            };

            return View(ivm);
        }


        public IActionResult Answer(string answer, Guid id)
        {
            var question = context.Get(id);

            OpenAnswerQuestionModel ivm = new OpenAnswerQuestionModel
            {
                Id = id,
                Question = question.QuestionText,
                Answer = question.Answer,
                IsAnswer = question.IsCorrectAnswer(answer)
            };

            return View(ivm);
        }

    }
}