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
            if (model.File is null)
            {
                model.AlertText = "Please upload a file before submitting.";
                return View(model);
            }
            int max_size = (int)Math.Pow(2, 15);
            var extension_index = model.File.FileName.LastIndexOf('.');
            var extesion = (extension_index >= 0) ? model.File.FileName.Substring(extension_index + 1) : null;
            if (extesion != "js" && extesion != "cs")
            {
                model.AlertText = $"Wrong extension .{extesion}! Please upload only .js and .cs files";
                return View(model);
            }
            if (model.File.Length > max_size)
            {
                model.AlertText = $"Too big file ({model.File.Length / 1024} kb). Please upload files less than 32 kb.";
                return View(model);
            }
            return Content("The file uploaded successfully!");
        }
    }
}
