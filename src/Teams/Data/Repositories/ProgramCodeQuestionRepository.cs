using System;
using System.Linq;
using Teams.Domain;

namespace Teams.Data.Repositories
{
    public class ProgramCodeQuestionRepository : IProgramCodeQuestionRepository
    {
        private ApplicationDbContext _db;
        public ProgramCodeQuestionRepository(ApplicationDbContext db)
        {
            _db = db;
        }
        public ProgramCodeQuestion PickById(Guid id)
        {
            return _db.ProgramCodeQuestions.Single(q => q.Id == id);
        }
    }
}
