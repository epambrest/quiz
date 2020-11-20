using System;
using Teams.Domain;

namespace Teams.Data.Repositories
{
    public interface IProgramCodeQuestionRepository
    {
        ProgramCodeQuestion PickById(Guid id);
    }
}
