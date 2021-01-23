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
        IProgramCodeQuestionRepository serviceQuestion;
        IProgramTestRepository serviceTest;
        ApplicationDbContext db;

        public ProgramTestController(IProgramCodeQuestionRepository _serviceQuestion, IProgramTestRepository _serviceTest, ApplicationDbContext _db)
        {
            db = _db;
            serviceQuestion = _serviceQuestion;
            serviceTest = _serviceTest;
        }

        [HttpGet]
        public IActionResult CreateProgramQuestion() => View();

        [HttpPost]
        public IActionResult CreateProgramQuestion(ProgramCodeQuestionViewModel programCodeQuestionView)
        {
            ProgramCodeQuestion programCodeQuestion = new ProgramCodeQuestion(programCodeQuestionView.Text);
            serviceQuestion.Add(programCodeQuestion);
            db.SaveChanges();
            return RedirectToAction("Index", "Home");
        }

        [HttpGet]
        public IActionResult AddTests(Guid id)
        {
            var question = serviceQuestion.PickById(id);   

            if (question == null) return NotFound();

            ProgramCodeQuestionViewModel programCodeQuestion = new ProgramCodeQuestionViewModel
            {
                Text = question.Text,
                Id = question.Id
            };

            return View(programCodeQuestion);
        }


        [HttpPost]
        public void SaveOrUpdate(ProgramTest progTest)
        {
            if (progTest.Id == 0) serviceTest.Save(progTest);
            else serviceTest.Update(progTest);
        }

        public string Delete(int id)
        {
            return serviceTest.Delete(id);
        }

        [HttpGet]
        public IEnumerable<ProgramTest> GetAllElements(Guid idQuestion)
        {
            return serviceTest.GetProgramCodeTests(idQuestion);
        }

        [HttpPost]
        public IActionResult SaveOrUpdteQuestion(ProgramCodeQuestionViewModel question)
        {
            ProgramCodeQuestion programQuestion = serviceQuestion.PickById(question.Id);
            programQuestion.InitialQuestion(question.Text);
            serviceQuestion.UpdateQuestion(programQuestion);

            ProgramCodeQuestionViewModel programCodeQuestion = new ProgramCodeQuestionViewModel
            {
                Text = programQuestion.Text,
                Id = programQuestion.Id
            };

            return View("AddTests", programCodeQuestion);
        }

        public IActionResult CheckingTests(ProgramCodeQuestionViewModel question)
        {
            return View(question);
        }
    }
}
