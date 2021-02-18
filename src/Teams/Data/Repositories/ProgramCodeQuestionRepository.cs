using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Teams.Domain;
using Teams.Models;

namespace Teams.Data.Repositories
{
    public class ProgramCodeQuestionRepository : IProgramCodeQuestionRepository
    {
        private ApplicationDbContext _db;
        public ProgramCodeQuestionRepository(ApplicationDbContext db)
        {
            _db = db;
        }
        public ProgramCodeQuestion PickById(Guid id)
        {
            return _db.ProgramCodeQuestions.Single(q => q.Id == id);
        }
        public async Task Add(ProgramCodeQuestion question)
        {
            await _db.ProgramCodeQuestions.AddAsync(question);
            await _db.SaveChangesAsync();

        }

        public async Task UpdateQuestion(ProgramCodeQuestion question)
        {
            _db.Questions.Update(question);
            await _db.SaveChangesAsync();
        }
    }
}
