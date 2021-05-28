﻿using System.Collections.Generic;
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
using System;
using Lab.Quiz.BL.Services.HomeService;

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

        public IActionResult Index()
        {
            _logger.LogInformation();
            ViewBag.Tests = _homeService.GetTests();
            return View();
        }

        [HttpPost]
        public PartialViewResult AddPartialToView(string id)
        {
            var testQuestions = _homeService.GetQuestions(Guid.Parse(id));
            return PartialView("_DisplayQuestionsPartial", testQuestions);
        }

        [HttpGet]
        public PartialViewResult Filter(string questionType, string testId)
        {
            var testQuestions = _homeService.FilterQuestions(Guid.Parse(testId), new QuestionType());
            return PartialView("_DisplayQuestionsPartial", testQuestions);
        }
    }
}
