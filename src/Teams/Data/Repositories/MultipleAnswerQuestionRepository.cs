using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Teams.Domain;

namespace Teams.Data.Repositories
{
    public class MultipleAnswerQuestionRepository : IMultipleAnswerQuestionRepository
    {
        IApplicationDbContext _db;
        public MultipleAnswerQuestionRepository(IApplicationDbContext db)
        {
            _db = db;
        }
        public MultipleAnswerQuestion PickById(Guid Id)
        {
            return _db.MultipleAnswerQuestions.Include(a => a.Answers).Single(q => q.Id == Id);
        }

        public void AddQuestion(MultipleAnswerQuestion question)
        {
            _db.MultipleAnswerQuestions.Add(question);
        }

        public void DeleteQuestionOptionsIn_DB(MultipleAnswerQuestion question)
        {
            question.Answers.ToList().ForEach(o => _db.Entry(o).State = EntityState.Deleted);
        }

        public void UpdateQuestion(MultipleAnswerQuestion question)
        {
            _db.MultipleAnswerQuestions.Update(question);
            _db.SaveChanges();
        }

    }
}