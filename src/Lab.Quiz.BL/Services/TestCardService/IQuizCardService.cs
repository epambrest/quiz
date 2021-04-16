using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Lab.Quiz.BL.Services.TestCardService.Models;

namespace Lab.Quiz.BL.Services.TestCardService
{
    public interface IQuizCardService
    {
        Task<ICollection<QuizCardBLModel>> GetAllQuizCards();

        Task CreateQuizCard(string testCardName);

        Task<QuizCardBLModel> GetQuizCard(Guid id);
    }
}
