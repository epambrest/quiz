using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Lab.Quiz.DAL.Interfaces;
using Lab.Quiz.DAL.Entities;

namespace Lab.Quiz.DAL.Repositories
{
    public class QuizCardRepository : IQuizCardRepository
    {
        private IApplicationDbContext _dbContext;
        public QuizCardRepository(IApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public List<QuizCardDALModel> GetAll()
        {
            return _dbContext.Tests.ToList();
        }
        public QuizCardDALModel Get(Guid id)
        {
            return _dbContext.Tests.Include(q => q.TestQuestions).FirstOrDefault(w => w.Id == id);
        }
    }
}
