using Microsoft.EntityFrameworkCore;    
using System;
using System.Linq;
using System.Threading.Tasks;
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

        public async Task<SingleSelectionQuestion> GetAsync(Guid id)
        {
            return await _dbContext.SingleSelectionQuestions
               .Include(q => q.Options)
               .FirstOrDefaultAsync(i => i.Id == id);
        }

        public void AddQuestion(SingleSelectionQuestion question)
        {
            _dbContext.SingleSelectionQuestions.Add(question);
            _dbContext.SaveChanges();
        }

        public void DeleteQuestionOptionsInDB(SingleSelectionQuestion question)
        {
            var options = question.Options
                .ToList();
            foreach(var o in options)
            {
                _dbContext.Entry(o).State = EntityState.Deleted;
            }
             _dbContext.SaveChanges();
        }

        public void UpdateQuestion(SingleSelectionQuestion question)
        {
            _dbContext.SingleSelectionQuestions.Update(question);
            _dbContext.SaveChanges();
        }
    }
}
