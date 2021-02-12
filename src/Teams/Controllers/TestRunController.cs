using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Teams.Data;
using Teams.Data.TestRunRepos;
using Teams.Domain;
using Teams.Models;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace Teams.Controllers
{
    public class TestRunController : Controller
    {
        private readonly ITestRunRepository _testRunRepository;
        private ApplicationUser _applicationUser;

        public TestRunController(ITestRunRepository testRunRepository,
            ApplicationDbContext context)
        {
            _testRunRepository = testRunRepository;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            return View(await _testRunRepository.GetAllAsync());
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] string userId, Guid testId)
        {
            var newTestRun = new TestRun(userId, testId);
            await _testRunRepository.AddAsync(newTestRun);
            _testRunRepository.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<IActionResult> Run(int testRunId)
        {
            var testRun = await _testRunRepository.GetByIdAsync(testRunId);
            if (testRun == null) return NotFound();
            var answers = testRun.Answers.Select(answer => new AnswerDto(answer.AnswerOptions.ToList(), answer.AnswerText,
                answer.TestQuestionId)).ToList();
            var testRunDto = new TestRunDto(answers, testRun.TestId);
            return View(testRunDto);
        }

        [HttpPost]
        public async Task<IActionResult> Run(TestRunDto testRunDto)
        {
            var updatedTestRun = await _testRunRepository.GetByIdAsync(testRunDto.Id);
            if (updatedTestRun == null) return NotFound();
            foreach (var answerDto in testRunDto.Answers)
            {
                if (answerDto.AnswerText == "")
                {
                    updatedTestRun.AddAnswer(new Answer(answerDto.TestQuestionId, answerDto.AnswerOptions));
                }
                else
                {
                    updatedTestRun.AddAnswer(new Answer(answerDto.TestQuestionId, answerDto.AnswerText));
                }
            }
            updatedTestRun.Finish();
            await _testRunRepository.AddAsync(updatedTestRun);
            return View(testRunDto);
        }

        /// <summary>
        /// This method is temporary, to be deleted after testing. It reads the context, gets the TestRun by id and returns back to caller.
        /// </summary>
        /// <returns></returns>
        public async Task<TestRun> PostRunTestMethod(int testRunId)
        {
            return await _testRunRepository.GetByIdAsync(testRunId);
        }
    }   
}