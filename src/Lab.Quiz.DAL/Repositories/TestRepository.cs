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
        public Test GetById(Guid id)
        {
            return _dbContext.Tests.Include(q => q.TestQuestions).FirstOrDefault(w => w.Id == id);
        }
        public async Task<Test> GetByIdAsync(Guid id)
        {
            return await _dbContext.Tests.Include(q => q.TestQuestions).FirstOrDefaultAsync(w => w.Id == id);
        }
        public IQueryable<Test> GetAll()
        {
            return _dbContext.Tests;
        }
        public void Add(Test entity)
        {
            _dbContext.Tests.Add(entity);
            _dbContext.SaveChanges();
        }
        public void AddAsync(Test entity)
        {
            _dbContext.Tests.AddAsync(entity);
            _dbContext.SaveChangesAsync();
        }
        public void Update(Test entity)
        {
            _dbContext.Tests.Update(entity);
            _dbContext.SaveChanges();
        }
        public void Delete(Test entity)
        {
            _dbContext.Tests.Remove(entity);
            _dbContext.SaveChanges();
        }
        public void DeleteTestQuestions(Guid id)
        {
            var testQuestions = _dbContext.TestQuestions.Where(w => w.TestId == id);
            _dbContext.TestQuestions.RemoveRange(testQuestions);
        }
    }
}
