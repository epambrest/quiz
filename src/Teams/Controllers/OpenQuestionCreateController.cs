using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using Teams.Data;
using Teams.Domain;
using Teams.Models;

namespace Teams.Controllers
{
    public class OpenQuestionCreateController : Controller
    {
        private readonly ApplicationDbContext _db;
        private readonly ILogger<OpenQuestionCreateController> _logger;
        public OpenQuestionCreateController(ApplicationDbContext db, ILogger<OpenQuestionCreateController> logger)
        {
            _db = db;
            _logger = logger;
        }

        public IActionResult Create()
        {
            _logger.LogInformation("");
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(OpenAnswerQuestionModel modelForView)
        {
            _logger.LogInformation("");
            OpenAnswerQuestion question = new OpenAnswerQuestion(modelForView.Question, modelForView.Answer);
            _db.OpenAnswerQuestions.Add(question);
            await _db.SaveChangesAsync();
            return RedirectToAction("Index", "Home");
        }

        public async Task<IActionResult> Edit(Guid id)
        {
            _logger.LogInformation($"Received id: {id}");
            OpenAnswerQuestion question = await _db.OpenAnswerQuestions.FirstOrDefaultAsync(p => p.Id == id);
            if (question != null)
            {
                OpenAnswerQuestionModel modelForView = new OpenAnswerQuestionModel
                { 
                    Question = question.Text,
                    Answer = question.Answer,
                    Id = question.Id 
                };

                return View(modelForView);
            }
            return NotFound();
        }
        [HttpPost]
        public async Task<IActionResult> Edit(OpenAnswerQuestionModel modelForView)
        {
            _logger.LogInformation("");
            OpenAnswerQuestion question = await _db.OpenAnswerQuestions.FirstOrDefaultAsync(p => p.Id == modelForView.Id);
            question.UpdateQuestion(modelForView.Question, modelForView.Answer);
            await _db.SaveChangesAsync();
            return RedirectToAction("Index","Home");
        }
    }
}