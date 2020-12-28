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
        private readonly UserManager<ApplicationUser> _userManager;
        private ApplicationUser _applicationUser;

        public TestRunController(ITestRunRepository testRunRepository,
            ApplicationDbContext context, UserManager<ApplicationUser> userManager)
        {
            _testRunRepository = testRunRepository;
            _context = context;
            _userManager = userManager;
        }
        
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            _applicationUser = await _userManager.GetUserAsync(User);
            return View(await _testRunRepository.GetAllAsync());
        }
        
        [HttpPost]
        public IActionResult Create([FromBody] string userId, Guid testId, List<Guid> answersIds)
        {
            var newTestRun = new TestRun(userId, testId, answersIds);
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
                    _context.Answers.Where(x => testQuestionIds.Contains(x.TestQuestionId)).ToList(),
                    testRun);
            var testRunDto = new TestRunDto(answers,
                _context.TestQuestions.Where(x => testQuestionIds.Contains(x.Id)).ToList(),
                testRun.TestId);
            return View(testRunDto);
        }

        [HttpPost]
        public async Task<IActionResult> Run(TestRunDto testRunDto)
        {
            var updatedTestRun = await _testRunRepository.GetByIdAsync(testRunDto.Id);
            if (updatedTestRun == null) return NotFound();
            if (testRunDto.Answers.Count == 0)
            {
                foreach (var answer in testRunDto.Answers)
                    updatedTestRun.AnswersIds.Add(answer.Id);
            }
            updatedTestRun.Finish();
            await SaveTestRun(updatedTestRun);
            return View(testRunDto);
        }


        [HttpPost]
        public async Task<IActionResult> AddAnswer(AnswerDto answerDto)
        {
            if (answerDto == null) return NotFound();
            var answer = new Answer(answerDto.AnswerOptions, answerDto.TestQuestionId, answerDto.Id);
            await SaveAnswer(answer);
            return View(answer);
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
        
        private async Task<bool> SaveAnswer(Answer answer)
        {
            try
            {
                _context.Answers.Update(answer);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public List<AnswerDto> AnswerDtoConvert(List<Answer> answers, TestRun testRun)
        {
            var answersDto = new List<AnswerDto>();
            foreach (var answer in answers)
                answersDto.Add(new AnswerDto(answer.AnswerOptions.ToList(), answer
                    .AnswerText, answer.Id, answer.TestQuestionId));

            return answersDto;
        }
    }
}