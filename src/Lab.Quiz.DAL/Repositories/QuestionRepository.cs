using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Lab.Quiz.DAL.Interfaces;
using Lab.Quiz.DAL.Entities;

namespace Lab.Quiz.DAL.Repositories
{
    public class QuestionRepository : IQuestionRepository
    {
        private IApplicationDbContext _dbContext;
        public QuestionRepository(IApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public List<Question> GetQuestions()
        {
            return _dbContext.Questions.ToList();
        }
        public List<Question> GetTestQuestions(Guid testId)
        {
            return _dbContext.TestQuestions.Where(w => w.TestId == testId).Select(w => w.Question).ToList();
        }
    }
}
