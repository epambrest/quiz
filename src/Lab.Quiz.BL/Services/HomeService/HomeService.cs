using Lab.Quiz.Common.Mapping;
using Lab.Quiz.DAL.Interfaces;
using Lab.Quiz.DAL.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Linq;
using Lab.Quiz.BL.Services.HomeService.Model;
using Lab.Quiz.BL.Services.TestCardService.Models;
using Lab.Quiz.BL.Services.TestCardService;

namespace Lab.Quiz.BL.Services.HomeService
{
    internal class HomeService : TestCardService.TestCardService, IHomeService, IFilterable
    {
        public HomeService(IUnitOfWork unitOfWork, IMapper mapper)
            : base(unitOfWork, mapper)
        {
        }

        public async Task<ICollection<Model.TestQuestionModel>> FilterQuestions(Guid testId, QuestionType questionType)
        {
            return GetQuestions(testId).Result.Where(x => x.QuestionType == questionType).ToList();
        }

        public async Task<ICollection<Model.TestQuestionModel>> GetQuestions(Guid testId)
        {
            var testQuestions = await _unitOfWork.TestQuestionsRepository.GetAll()
                .Where(x=>x.TestId == testId)
                .ToListAsync();

            return _mapper.Map<ICollection<TestQuestion>, ICollection<Model.TestQuestionModel>>(testQuestions);
        }
    }
}
