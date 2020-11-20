using System;
using Teams.Domain;

namespace Teams.Data.Repositories
{
    public interface IMultipleAnswerQuestionRepository
    {
        MultipleAnswerQuestion PickById(Guid Id);
    }
}
