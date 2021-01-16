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
        private readonly ApplicationDbContext _context;
        // private readonly UserManager<ApplicationUser> _userManager;
        private ApplicationUser _applicationUser;

        public TestRunController(ITestRunRepository testRunRepository,
            ApplicationDbContext context)
        {
            _testRunRepository = testRunRepository;
            _context = context;
            // _userManager = userManager;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            // _applicationUser = await _userManager.GetUserAsync(User);
            return View(await _testRunRepository.GetAllAsync());
        }

        [HttpPost]
        public IActionResult Create([FromBody] string userId, Guid testId)
        {
            var newTestRun = new TestRun(userId, testId);
            _context.TestRuns.Add(newTestRun);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<IActionResult> Run(Guid testRunId)
        {
            var testRun = await _testRunRepository.GetByIdAsync(testRunId);
            if (testRun == null) return NotFound();
            var testQuestionIds =
                _context.TestQuestions.Where(q => q.TestId == testRun.TestId).Select(x => x.Id).ToList();
            var answers =
                AnswerDtoConvert(
                    _context.Answers.Where(x => testQuestionIds.Contains(x.TestQuestionId)).ToList());
            var testRunDto = new TestRunDto(answers,
                _context.TestQuestions.Where(x => testQuestionIds.Contains(x.Id)).ToList());
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
            await SaveTestRun(updatedTestRun);
            return View(testRunDto);
        }

        /// <summary>
        /// This method is temporary, to be deleted after testing. It reads the context, gets the TestRun by id and returns back to caller.
        /// </summary>
        /// <returns></returns>
        public async Task<TestRun> PostRunTestMethod(Guid testRunId)
        {
            return await _testRunRepository.GetByIdAsync(testRunId);
        }

        private async Task<bool> SaveTestRun(TestRun testRun)
        {
            try
            {
                _context.TestRuns.Update(testRun);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public List<AnswerDto> AnswerDtoConvert(List<Answer> answers)
        {
            return answers.Select(answer => new AnswerDto(answer.AnswerOptions.ToList(), answer.AnswerText, 
                answer.TestQuestionId)).ToList();
        }
    }
}