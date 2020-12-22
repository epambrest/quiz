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
        public async void AddAsync(Guid id, string text)
        {
            var model = new QueuedProgram(id, text);
            await _db.QueuedPrograms.AddAsync(model);
        }
    }
}
