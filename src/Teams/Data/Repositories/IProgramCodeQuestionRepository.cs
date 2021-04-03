using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Teams.Domain;

namespace Teams.Data.Repositories
{
    public interface IProgramCodeQuestionRepository
    {
        ProgramCodeQuestion PickById(Guid id);
        Task Add(ProgramCodeQuestion question);
        Task UpdateQuestion(ProgramCodeQuestion question);
    }
}
