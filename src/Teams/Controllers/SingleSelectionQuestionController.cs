using Microsoft.AspNetCore.Mvc;
using System;
using Teams.Data.SingleSelectionQuestionRepos;

namespace Teams.Controllers
{
    public class SingleSelectionQuestionController : Controller
    {
        private ISingleSelectionQuestionRepository _singleRepository { get; set; }
        public SingleSelectionQuestionController(ISingleSelectionQuestionRepository singleRepository)
        {
            _singleRepository = singleRepository;
        }
        [Route("[Controller]/{id?}")]
        public IActionResult Index(Guid id)
        {
            var question = _singleRepository.Get(id);
            if (question == null) return NotFound();
            return View(question);
        }
        [HttpGet]
        public JsonResult FindAnswer(Guid questionId)
        {
            var question = _singleRepository.Get(questionId);
            var answer = question.GetRightAnswer();
            return Json(answer);
        }
    }
}
