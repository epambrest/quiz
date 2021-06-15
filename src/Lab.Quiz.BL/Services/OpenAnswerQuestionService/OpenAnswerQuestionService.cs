using Lab.Quiz.DAL.Interfaces;
using System;
using System.Threading.Tasks;
using Lab.Quiz.DAL.Entities;
using Lab.Quiz.Common.Mapping;
using Lab.Quiz.BL.Services.OpenAnswerQuestionService.Models;

namespace Lab.Quiz.BL.Services.OpenAnswerQuestionService
{
    public class OpenAnswerQuestionService : IOpenAnswerQuestionService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public OpenAnswerQuestionService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task<OpenAnswerQuestionModel> Get(Guid id)
        {
            var answer = await _unitOfWork.OpenAnswerQuestionsRepository.GetByIdAsync(id);
            return _mapper.Map<OpenAnswerQuestion, OpenAnswerQuestionModel>(answer);
        }

        public bool IsCorrectAnswer(string answer, string entityAnswer)
        {
            answer = answer.Trim();
            return answer == entityAnswer;
        }
    }
}
