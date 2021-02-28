using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Lab.Quiz.DAL.Entities;

namespace Lab.Quiz.DAL.Interfaces
{
    public interface ISingleSelectionQuestionRepository
    {
        Task<SingleSelectionQuestion> GetAsync(Guid id);
        void AddQuestion(SingleSelectionQuestion question);
        void DeleteQuestionOptionsInDB(SingleSelectionQuestion question);
        void UpdateQuestion(SingleSelectionQuestion question);
    }
}
