using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Teams.Data;
using Teams.Data.ProgramTestRepos;
using Teams.Data.Repositories;
using Teams.Domain;
using Teams.Models;

namespace Teams.Controllers
{
    public class ProgramTestController : Controller
    {
        private  IProgramCodeQuestionRepository _questionRepository;
        private IProgramTestRepository _testRepository;
        private ApplicationDbContext _context;

        public ProgramTestController(IProgramCodeQuestionRepository questionRepository, IProgramTestRepository testRepository, ApplicationDbContext context)
        {
            _context = context;
            _testRepository = testRepository;
            _questionRepository = questionRepository;
        }        

        public IActionResult CreateProgramQuestion() => View();

        [HttpPost]
        public async Task<IActionResult> CreateProgramQuestion(ProgramCodeQuestionViewModel programCodeQuestionView)
        {
            var programCodeQuestion = new ProgramCodeQuestion(programCodeQuestionView.Text);
            _questionRepository.Add(programCodeQuestion);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index", "Home");
        }

        public IActionResult AddTests(Guid id)
        {
            var question = _questionRepository.PickById(id);

            if(question == null) return NotFound();

            var programCodeQuestion = new ProgramCodeQuestionViewModel
            {
                Text = question.Text,
                Id = question.Id
            };

            return View(programCodeQuestion);
        }


        [HttpPost]
        public async Task SaveTest(ProgramTest progTest)
        {            
            await _testRepository.Save(progTest);
        }

        [HttpDelete]       
        public async Task<IActionResult> DeleteTest(int id)
        {
            await _testRepository.Delete(id);
            return Ok();
        }

        [HttpGet]
        public async Task<IActionResult> GetAllElements(Guid idQuestion)
        {
            var result = await _testRepository.GetProgramCodeTests(idQuestion);
            return Ok(result);
        }


        [HttpPost]
        public IActionResult UpdateQuestion(ProgramCodeQuestionViewModel question)
        {
            var programQuestion = _questionRepository.PickById(question.Id);
            programQuestion.InitialQuestion(question.Text);
            _questionRepository.UpdateQuestion(programQuestion);

            var programCodeQuestion = new ProgramCodeQuestionViewModel
            {
                Text = programQuestion.Text,
                Id = programQuestion.Id
            };

            return View("AddTests", programCodeQuestion);
        }

        [HttpPost]
        public IActionResult CheckingTests(ProgramCodeQuestionViewModel question)
        {
            return View(question);
        }

        public async Task<IActionResult> EditTest(int id)
        {
            var result = await _testRepository.GetByIdTest(id);
            return PartialView(result);
        }

        [HttpPost]
        public async  Task<IActionResult> EditTest(ProgramTest programTest)
        {
            await _testRepository.Update(programTest);
            var quest = _questionRepository.PickById(programTest.QuestionId);
            return RedirectToAction("AddTests", new { id = quest.Id });
        } 
    }
}
