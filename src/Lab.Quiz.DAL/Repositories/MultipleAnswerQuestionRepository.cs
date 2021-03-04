using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Lab.Quiz.DAL.Entities;
using Lab.Quiz.DAL.Interfaces;

namespace Lab.Quiz.DAL.Repositories
{
    public class MultipleAnswerQuestionRepository : IMultipleAnswerQuestionRepository
    {
        IApplicationDbContext _dbContext;
        public MultipleAnswerQuestionRepository(IApplicationDbContext db)
        {
            _dbContext = db;
        }
        public MultipleAnswerQuestion GetById(Guid Id)
        {
            return _dbContext.MultipleAnswerQuestions.Include(a => a.Answers).Single(q => q.Id == Id);
        }

        public async Task<MultipleAnswerQuestion> GetByIdAsync(Guid Id)
        {
            return await _dbContext.MultipleAnswerQuestions.Include(a => a.Answers).SingleAsync(q => q.Id == Id);
        }

        public IQueryable<MultipleAnswerQuestion> GetAll()
        {
            return _dbContext.MultipleAnswerQuestions;
        }

        public void Add(MultipleAnswerQuestion entity)
        {
            _dbContext.MultipleAnswerQuestions.Add(entity);
            _dbContext.SaveChanges();
        }

        public void AddAsync(MultipleAnswerQuestion entity)
        {
            _dbContext.MultipleAnswerQuestions.AddAsync(entity);
            _dbContext.SaveChangesAsync();
        }

        public void DeleteQuestionOptionsInDB(MultipleAnswerQuestion entity)
        {
            var answers = entity.Answers.ToList();

            foreach (var a in answers)
            {
                _dbContext.Entry(a).State = EntityState.Deleted;
            }
            _dbContext.SaveChanges();
        }

        public void Update(MultipleAnswerQuestion entity)
        {
            _dbContext.MultipleAnswerQuestions.Update(entity);
            _dbContext.SaveChanges();
        }
        public void Delete(MultipleAnswerQuestion entity)
        {
            _dbContext.MultipleAnswerQuestions.Remove(entity);
            _dbContext.SaveChanges();
        }
    }
}