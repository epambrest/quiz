using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Teams.Extensions;
using Lab.Quiz.DAL.Entities;
using Lab.Quiz.DAL.Repositories;
using Lab.Quiz.DAL;
using Lab.Quiz.DAL.Interfaces;

namespace Teams.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ITestRepository _testsRepo;
        private readonly IQuestionRepository _questionsRepo;

        public HomeController(ILogger<HomeController> logger, ITestRepository testRepo, IQuestionRepository questionRepo)
        {
            _testsRepo = testRepo;
            _questionsRepo = questionRepo;
            _logger = logger;
        }

        public IActionResult Index()
        {
            _logger.LogInformation();
            ViewBag.Tests = _testsRepo.GetAll();
            ViewBag.Questions = _questionsRepo.GetQuestions();
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            _logger.LogInformation();
            ViewBag.tests = _testsRepo.GetAll();
            return View();
        }
    }
}
