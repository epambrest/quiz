using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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
        public OpenQuestionCreateController(ApplicationDbContext db)
        {
            _db = db;
        }

        public async Task<IActionResult> Index()
        {
            return View(await _db.OpenAnswerQuestions.ToListAsync());
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(OpenAnswerQuestionModel ModelForView)
        {
            OpenAnswerQuestion Question = new OpenAnswerQuestion(ModelForView.Question, ModelForView.Answer);
            _db.OpenAnswerQuestions.Add(Question);
            await _db.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Details(Guid id)
        {
            if (id != null)
            {
                OpenAnswerQuestion question = await _db.OpenAnswerQuestions.Include(a => a.Answer).FirstOrDefaultAsync(p => p.Id == id);
                OpenAnswerQuestionModel ModelForView = new OpenAnswerQuestionModel { Question = question.Text, Answer = question.Answer.AnswerText, Id = question.Id };
                if (ModelForView != null)
                    return View(ModelForView);
            }
            return NotFound();
        }

        public async Task<IActionResult> Edit(Guid id)
        {
            if (id != null)
            {
                OpenAnswerQuestion question = await _db.OpenAnswerQuestions.Include(a => a.Answer).FirstOrDefaultAsync(p => p.Id == id);
                OpenAnswerQuestionModel ModelForView = new OpenAnswerQuestionModel { Question = question.Text, Answer = question.Answer.AnswerText, Id = question.Id };
                if (ModelForView != null)
                    return View(ModelForView);
            }
            return NotFound();
        }
        [HttpPost]
        public async Task<IActionResult> Edit(OpenAnswerQuestionModel ModelForView)
        {
            OpenAnswerQuestion Question = await _db.OpenAnswerQuestions.Include(a => a.Answer).FirstOrDefaultAsync(p => p.Id == ModelForView.Id);
            _db.Entry(Question).State = EntityState.Deleted;
            _db.Entry(Question.Answer).State = EntityState.Deleted;
            Question = new OpenAnswerQuestion(ModelForView.Question, ModelForView.Answer);
            
            _db.OpenAnswerQuestions.Update(Question);
            await _db.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        [HttpGet]
        [ActionName("Delete")]
        public async Task<IActionResult> ConfirmDelete(Guid id)
        {
            if (id != null)
            {
                OpenAnswerQuestion question = await _db.OpenAnswerQuestions.Include(a => a.Answer).FirstOrDefaultAsync(p => p.Id == id);
                OpenAnswerQuestionModel ModelForView = new OpenAnswerQuestionModel { Question = question.Text, Answer = question.Answer.AnswerText };
                if (ModelForView != null)
                    return View(ModelForView);
            }
            return NotFound();
        }

        [HttpPost]
        public async Task<IActionResult> Delete(Guid id)
        {
            if (id != null)
            {
                OpenAnswerQuestion question = await _db.OpenAnswerQuestions.Include(a => a.Answer).FirstOrDefaultAsync(p => p.Id == id);
                _db.Entry(question).State = EntityState.Deleted;
                _db.Entry(question.Answer).State = EntityState.Deleted;
                await _db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return NotFound();
        }
    }
}
