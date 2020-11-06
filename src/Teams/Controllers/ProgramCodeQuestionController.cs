using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Teams.Data.Repositories;
using Teams.Domain;
using Teams.Models;
using static System.IO.File;

namespace Teams.Controllers
{
    public class ProgramCodeQuestionController : Controller
    {
        private IProgramCodeQuestionRepository questionRepository;
        public ProgramCodeQuestionController(IProgramCodeQuestionRepository questionRepository)
        {
            this.questionRepository = questionRepository;
        }
        [HttpGet]
        public IActionResult Index(Guid id)
        {
            var question = questionRepository.PickById(id);
            var model = new ProgramCodeQuestionViewModel()
            {
                Id = question.Id,
                Text = question.Text
            };
            return View(model);
        }
        [HttpPost]
        public IActionResult Index(ProgramCodeQuestionViewModel model)
        {
            // Some actions to implement
            return Content($"The file for {model.Text} uploaded");
        }
    }
}
