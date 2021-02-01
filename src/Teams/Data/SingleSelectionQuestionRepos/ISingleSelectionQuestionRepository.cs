using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Teams.Domain;

namespace Teams.Data.SingleSelectionQuestionRepos
{
    public interface ISingleSelectionQuestionRepository
    {
        Task<SingleSelectionQuestion> GetAsync(Guid id);
        void AddQuestion(SingleSelectionQuestion question);
        void DeleteQuestionOptionsInDB(SingleSelectionQuestion question);
        void UpdateQuestion(SingleSelectionQuestion question);
    }
}
