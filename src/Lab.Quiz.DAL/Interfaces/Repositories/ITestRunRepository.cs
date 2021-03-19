using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Lab.Quiz.DAL.Entities;

namespace Lab.Quiz.DAL.Interfaces
{
    public interface ITestRunRepository
    {
        public Task<List<TestRun>> GetAllAsync();
        public Task<TestRun> GetByIdAsync(int id);
        public Task<bool> AddAsync(TestRun testRun);
        public bool SaveChanges();
        public Task<List<TestRun>> GetAllByUserAsync(string id);
    }
}
