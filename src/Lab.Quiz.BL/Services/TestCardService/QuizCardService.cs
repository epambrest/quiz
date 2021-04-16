using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Lab.Quiz.BL.Services.TestCardService.Models;
using Lab.Quiz.Common.Mapping;
using Lab.Quiz.DAL.Entities;
using Lab.Quiz.DAL.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Lab.Quiz.BL.Services.TestCardService
{
    internal class QuizCardService : IQuizCardService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public QuizCardService(
            IUnitOfWork unitOfWork,
            IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<ICollection<QuizCardBLModel>> GetAllQuizCards()
        {
            var tests = await _unitOfWork.QuizCardRepository.GetAll()
                .Include(x => x.TestQuestions)
                .ToListAsync();

            return _mapper.Map<ICollection<QuizCardDALModel>, ICollection<QuizCardBLModel>>(tests);
        }

        public async Task CreateQuizCard(string testCardName)
        {
         var testCardVModel =  _mapper.Map<QuizCardBLModel, QuizCardDALModel>(new QuizCardBLModel {TestTitle = testCardName });
         _unitOfWork.QuizCardRepository.Add(testCardVModel);
         await _unitOfWork.SaveAsync();
        }

        public async Task<QuizCardBLModel> GetQuizCard(Guid id)
        {
            var quizCard = _unitOfWork.QuizCardRepository.GetAll()
                .Where(q => q.Id == id)
                .Include(q => q.TestQuestions)
                .First();
            return  _mapper.Map<QuizCardDALModel, QuizCardBLModel>(quizCard);
        }
    }
}
