using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Lab.Quiz.DAL.Interfaces;
using Lab.Quiz.DAL.Entities;
using Lab.Quiz.DAL;

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
        public void Add(ProgramCodeQuestion question)
        {
            _db.ProgramCodeQuestions.Add(question);
        }
    }
}
