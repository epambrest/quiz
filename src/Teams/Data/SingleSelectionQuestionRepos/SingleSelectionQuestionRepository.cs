using Microsoft.EntityFrameworkCore;    
using System;
using System.Linq;
using Teams.Domain;

namespace Teams.Data.SingleSelectionQuestionRepos
{
    public class SingleSelectionQuestionRepository: ISingleSelectionQuestionRepository
    {
        private IApplicationDbContext _dbContext;
        public SingleSelectionQuestionRepository(IApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public SingleSelectionQuestion Get(Guid id)
        {
            return _dbContext.SingleSelectionQuestions.Include(q => q.Options)
               .FirstOrDefault(i => i.Id == id);
        }

        public void AddQuestion(SingleSelectionQuestion question)
        {
            _dbContext.SingleSelectionQuestions.Add(question);
            _dbContext.SaveChanges();
        }

        public void DeleteQuestionOptionsIn_DB(SingleSelectionQuestion question)
        {
            question.Options.ToList().ForEach(o => _dbContext.Entry(o).State = EntityState.Deleted);
        }

        public void UpdateQuestion(SingleSelectionQuestion question)
        {
            _dbContext.SingleSelectionQuestions.Update(question);
            _dbContext.SaveChanges();
        }
    }
}
