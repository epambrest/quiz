using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Teams.Extensions;
using System;
using Lab.Quiz.BL.Services.HomeService;
using Lab.Quiz.BL.Services.HomeService.Models;
using Lab.Quiz.BL.Services.TestCardService.Models;

namespace Teams.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IHomeService _homeService;

        public HomeController(ILogger<HomeController> logger, IHomeService homeService)
        {
            _logger = logger;
            _homeService = homeService;
        }

        public async Task<IActionResult> Index()
        {
            _logger.LogInformation();
            ViewBag.Tests = await _homeService.GetTests();
            return View();
        }

        [HttpGet]
        public IActionResult AddPartialToView(string id)
        {
            var testQuestions = _homeService.GetTestQuestions(id);
            return PartialView("_DisplayQuestionsPartial", testQuestions);
        }

        [HttpGet]
        public PartialViewResult Filter(string testId, string questionType)
        {
            var testQuestions = _homeService.FilterQuestions(testId, questionType);
            var questions = _homeService.GetQuestions(testQuestions);
            ViewBag.TestQuestions = testQuestions;
            ViewBag.Questions = questions;
            var questionsModel =
                new Tuple<ICollection<QuestionModel>, ICollection<TestQuestionModel>>(questions, testQuestions);
            return PartialView("_DisplayTextPartial", questionsModel);
        }
    }
}
 