using Lab.Quiz.Common.Mapping;
using Lab.Quiz.DAL.Interfaces;
using Lab.Quiz.DAL.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using Lab.Quiz.BL.Services.HomeService.Models;
using Lab.Quiz.BL.Services.TestCardService.Models;

namespace Lab.Quiz.BL.Services.HomeService
{
    internal class HomeService : IHomeService, IFilterable
    {
        protected readonly IUnitOfWork _unitOfWork;
        protected readonly IMapper _mapper;

        public HomeService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public ICollection<TestQuestionModel> FilterQuestions(string testId, string questionType)
        {
            var type = (QuestionType)Enum.Parse(typeof(QuestionType), questionType);
            var filteredQuestions = GetTestQuestions(testId).Where(x => x.QuestionType.Equals(type)).ToList();
            var questions = GetQuestions(filteredQuestions);
            return filteredQuestions;
        }

        public ICollection<TestQuestionModel> GetTestQuestions(string testId)
        {
            var testQuestions = this._unitOfWork.TestQuestionsRepository.GetAll().Where(t=>t.TestId == Guid.Parse(testId)).ToList();
            return _mapper.Map<ICollection<TestQuestion>, ICollection<TestQuestionModel>>(testQuestions);
        }

        public ICollection<QuestionModel> GetQuestions(ICollection<TestQuestionModel> testQuestionModels)
        {
            var filteredQuestions = this._unitOfWork.QuestionsRepository.GetAll().Where(q => testQuestionModels.Any(t => t.QuestionId == q.Id)).ToList();

            return _mapper.Map<ICollection<Question>, ICollection<QuestionModel>>(filteredQuestions);
        }

        public async Task<ICollection<TestCardModel>> GetTests()
        {
            var tests = await _unitOfWork.TestsRepository.GetAll()
                .Include(x => x.TestQuestions)
                .ToListAsync();

            return _mapper.Map<ICollection<Test>, ICollection<TestCardModel>>(tests);
        }
    }
}
