using Lab.Quiz.BL.Services.OpenAnswerQuestionService.Models;
using Lab.Quiz.DAL.Entities;
using System;
using System.Threading.Tasks;

namespace Lab.Quiz.BL.Services.OpenAnswerQuestionService
{
    public interface IOpenAnswerQuestionService
    {
        Task<OpenAnswerQuestionModel> Get(Guid id);
        bool IsCorrectAnswer(string answer, string entityAnswer);
    }
}
