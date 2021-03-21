using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Teams.Domain;
using Teams.Data;
using Microsoft.EntityFrameworkCore;
using Teams.Data.SingleSelectionQuestionRepos;

namespace Teams.Controllers
{
    public class SingleSelectionQuestionController : Controller
    {
        private ISingleSelectionQuestionRepository _singleRepository { get; set; }
        private readonly ILogger<SingleSelectionQuestionController> _logger;
        public SingleSelectionQuestionController(ISingleSelectionQuestionRepository singleRepository,
            ILogger<SingleSelectionQuestionController> logger)
        {
            _singleRepository = singleRepository;
            _logger = logger;
        }
        [Route("[Controller]/{id?}")]
        public IActionResult Index(Guid id)
        {
            _logger.LogInformation($"Recieved GUID: {id}");
            var question = _singleRepository.GetAsync(id);
            if (question == null) return NotFound();
            return View(question);
        }
        [HttpGet]
        public async Task<JsonResult> FindAnswer(Guid questionId)
        {
            _logger.LogInformation($"Recieved GUID: {questionId}");
            var question = await _singleRepository.GetAsync(questionId);
            var answer =  question.GetRightAnswer();
            return Json(answer);
        }
    }
}
