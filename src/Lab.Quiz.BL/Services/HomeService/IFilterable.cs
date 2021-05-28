using Lab.Quiz.BL.Services.HomeService.Model;
using Lab.Quiz.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Lab.Quiz.BL.Services.HomeService
{
    public interface IFilterable
    {
        Task<ICollection<TestQuestionModel>> FilterQuestions(Guid testId, QuestionType questionType);
    }
}
