using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Teams.Domain;

namespace Teams.Data.SingleSelectionQuestionRepos
{
    public interface ISingleSelectionQuestionRepository
    {
        SingleSelectionQuestion Get(Guid id);
        void AddQuestion(SingleSelectionQuestion question);
        void DeleteQuestionOptionsIn_DB(SingleSelectionQuestion question);
        void UpdateQuestion(SingleSelectionQuestion question);
    }
}
