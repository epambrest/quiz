using Microsoft.EntityFrameworkCore;    
using System;
using System.Linq;
using System.Threading.Tasks;
using Lab.Quiz.DAL.Interfaces;
using Lab.Quiz.DAL.Entities;
using System.Collections.Generic;

namespace Lab.Quiz.DAL.Repositories
{
    public class SingleSelectionQuestionRepository: ISingleSelectionQuestionRepository
    {
        private IApplicationDbContext _dbContext;
        public SingleSelectionQuestionRepository(IApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public SingleSelectionQuestion GetById(Guid id)
        {
            return _dbContext.SingleSelectionQuestions
               .Include(q => q.Options)
               .FirstOrDefault(i => i.Id == id);
        }

        public async Task<SingleSelectionQuestion> GetByIdAsync(Guid id)
        {
            return await _dbContext.SingleSelectionQuestions
               .Include(q => q.Options)
               .FirstOrDefaultAsync(i => i.Id == id);
        }

        public IQueryable<SingleSelectionQuestion> GetAll()
        {
            return _dbContext.SingleSelectionQuestions;
        }

        public void Add(SingleSelectionQuestion entity)
        {
            _dbContext.SingleSelectionQuestions.Add(entity);
            _dbContext.SaveChanges();
        }

        public void AddAsync(SingleSelectionQuestion entity)
        {
            _dbContext.SingleSelectionQuestions.AddAsync(entity);
            _dbContext.SaveChangesAsync();
        }

        public void DeleteQuestionOptionsInDB(SingleSelectionQuestion entity)
        {
            var options = entity.Options
                .ToList();
            foreach(var o in options)
            {
                _dbContext.Entry(o).State = EntityState.Deleted;
            }
             _dbContext.SaveChanges();
        }

        public void Update(SingleSelectionQuestion entity)
        {
            _dbContext.SingleSelectionQuestions.Update(entity);
            _dbContext.SaveChanges();
        }

        public void Delete(SingleSelectionQuestion entity)
        {
            _dbContext.SingleSelectionQuestions.Remove(entity);
            _dbContext.SaveChanges();
        }
    }
}
