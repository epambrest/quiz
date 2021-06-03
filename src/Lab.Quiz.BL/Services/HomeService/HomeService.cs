using Lab.Quiz.Common.Mapping;
using Lab.Quiz.DAL.Interfaces;
using Lab.Quiz.DAL.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Linq;
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

        public async Task<ICollection<TestQuestionModel>> FilterQuestions(string testId, string questionType)
        {
            var type = (QuestionType)Enum.Parse(typeof(QuestionType), questionType);
            var testQuestions = GetQuestions(testId);
            var filteredQuestions = testQuestions.Where(x => x.QuestionType.Equals(type)).ToList();
            var result = testQuestions.Where(x => x.TestId.ToString() == testId).ToList();
            return filteredQuestions;
        }

        public ICollection<TestQuestionModel> GetQuestions(string testId)
        {
            var testQuestions = _unitOfWork.TestQuestionsRepository.GetAll().Where(t=>t.TestId == Guid.Parse(testId)).ToList();
            return _mapper.Map<ICollection<TestQuestion>, ICollection<TestQuestionModel>>(testQuestions);
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
