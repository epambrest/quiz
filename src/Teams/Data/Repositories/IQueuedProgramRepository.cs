using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Teams.Domain;
using Teams.Models;

namespace Teams.Data.Repositories
{
    public interface IQueuedProgramRepository
    {
        void Add(Guid id, string text);
        void Update(QueuedProgram program);
    }
}
