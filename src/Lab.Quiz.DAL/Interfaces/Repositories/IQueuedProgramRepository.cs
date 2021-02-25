using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Lab.Quiz.DAL.Interfaces
{
    public interface IQueuedProgramRepository
    {
        void Add(Guid id, string text);
    }
}
