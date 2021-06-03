using Lab.Quiz.BL.Services.TestCardService.Models;
using Lab.Quiz.BL.Services.TestCardService;
using Lab.Quiz.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Lab.Quiz.BL.Services.HomeService
{
    public interface IHomeService : IFilterable
    {
        ICollection<TestQuestionModel> GetQuestions(string id);

        Task<ICollection<TestCardModel>> GetTests();
    }
}
