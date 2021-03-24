using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Lab.Quiz.DAL.Entities;

namespace Lab.Quiz.DAL.Interfaces
{
    public interface IMultipleAnswerQuestionRepository
    {
        MultipleAnswerQuestion PickById(Guid Id);

        void AddQuestion(MultipleAnswerQuestion question);

        void UpdateQuestion(MultipleAnswerQuestion question);

        void DeleteQuestionOptionsInDB(MultipleAnswerQuestion question);

    }


}
