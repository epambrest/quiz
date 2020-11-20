using System;
using Teams.Domain;

namespace Teams.Data.OpenAnswerQuestionRepos
{
    public interface IOpenAnswerQuestionRepository
    {
        public OpenAnswerQuestion Get(Guid id);
    }
}
