using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Teams.Domain;
using Teams.Models;

namespace Teams.Data.Repositories
{
    public class QueuedProgramRepository : IQueuedProgramRepository
    {
        private ApplicationDbContext _db;
        public QueuedProgramRepository(ApplicationDbContext db)
        {
            _db = db;
        }
        public void Add(ProgramCodeQuestion question, string text)
        {
            var model = new QueuedProgram()
            {
                QuestionId = question.Id,
                Program = text,
                Status = 0
            };
            _db.QueuedPrograms.Add(model);
        }
        public void Save()
        {
            _db.SaveChanges();
        }
    }
}
