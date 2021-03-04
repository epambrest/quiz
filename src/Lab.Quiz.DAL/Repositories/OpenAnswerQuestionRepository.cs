using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Lab.Quiz.DAL.Interfaces;
using Lab.Quiz.DAL.Entities;
using Microsoft.EntityFrameworkCore;

namespace Lab.Quiz.DAL.Repositories
{
    public class OpenAnswerQuestionRepository : IOpenAnswerQuestionRepository
    {
        IApplicationDbContext _dbContext;
        public OpenAnswerQuestionRepository(IApplicationDbContext context)
        {
            _dbContext = context;
        }
        public OpenAnswerQuestion GetById(Guid id)
        {
            return _dbContext.OpenAnswerQuestions.FirstOrDefault(x => x.Id == id);
        }
        public async Task<OpenAnswerQuestion> GetByIdAsync(Guid id)
        {
            return await _dbContext.OpenAnswerQuestions.FirstOrDefaultAsync(x => x.Id == id);
        }
        public IQueryable<OpenAnswerQuestion> GetAll()
        {
            return _dbContext.OpenAnswerQuestions;
        }
        public void Add(OpenAnswerQuestion entity)
        {
            _dbContext.OpenAnswerQuestions.Add(entity);
            _dbContext.SaveChanges();
        }
        public void AddAsync(OpenAnswerQuestion entity)
        {
            _dbContext.OpenAnswerQuestions.AddAsync(entity);
            _dbContext.SaveChangesAsync();
        }
        public void Update(OpenAnswerQuestion entity)
        {
            _dbContext.OpenAnswerQuestions.Update(entity);
            _dbContext.SaveChanges();
        }
        public void Delete(OpenAnswerQuestion entity)
        {
            _dbContext.OpenAnswerQuestions.Remove(entity);
            _dbContext.SaveChanges();
        }
    }
}
