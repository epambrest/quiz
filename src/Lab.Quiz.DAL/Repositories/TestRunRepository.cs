using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Lab.Quiz.DAL.Interfaces;
using Lab.Quiz.DAL.Entities;

namespace Lab.Quiz.DAL.Repositories
{
    public class TestRunRepository : ITestRunRepository
    {
        private readonly IApplicationDbContext _dbContext;

        public TestRunRepository(IApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<TestRun>> GetAllAsync() => await _dbContext.TestRuns.ToListAsync();

        public async Task<TestRun> GetByIdAsync(int id) =>  await _dbContext.TestRuns.FirstOrDefaultAsync(x=>x.Id == id);

        public async Task<bool> AddAsync(TestRun testRun)
        {
            await _dbContext.TestRuns.AddAsync(testRun);
            return SaveChanges();
        }

        public bool SaveChanges()
        {
            try
            {
                _dbContext.SaveChanges();
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public async Task<List<TestRun>> GetAllByUserAsync(string id)
        {
            var testRuns = await GetAllAsync();
            return testRuns.Where(x => x.TestedUserId == id).ToList();
        }
    }
}
