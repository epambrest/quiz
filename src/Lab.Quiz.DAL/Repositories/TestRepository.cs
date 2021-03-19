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
    public class TestRepository : ITestRepository
    {
        private IApplicationDbContext _dbContext;
        public TestRepository(IApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public List<Test> GetAll()
        {
            return _dbContext.Tests.ToList();
        }
        public Test Get(Guid id)
        {
            return _dbContext.Tests.Include(q => q.TestQuestions).FirstOrDefault(w => w.Id == id);
        }
    }
}
