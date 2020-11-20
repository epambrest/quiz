using System;
using Teams.Domain;

namespace Teams.Data.SingleSelectionQuestionRepos
{
    public interface ISingleSelectionQuestionRepository
    {
        SingleSelectionQuestion Get(Guid id);
    }
}
