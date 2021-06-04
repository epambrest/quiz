using Lab.Quiz.BL.Services.TestCardService.Models;
using System.Collections.Generic;
using System.Threading.Tasks;
using Lab.Quiz.BL.Services.HomeService.Models;

namespace Lab.Quiz.BL.Services.HomeService
{
    public interface IHomeService : IFilterable
    {
        ICollection<TestQuestionModel> GetTestQuestions(string id);

        Task<ICollection<TestCardModel>> GetTests();

        ICollection<QuestionModel> GetQuestions(ICollection<TestQuestionModel> testQuestionModels); }
}
