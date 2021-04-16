using System.Linq;
using Lab.Quiz.BL.Services.TestCardService.Models;
using Lab.Quiz.Common.Mapping;
using Lab.Quiz.DAL.Entities;

namespace Lab.Quiz.BL.Services.TestCardService.Mapping
{
    /// <summary>
    /// The <see cref="IManualMapperProfile"/> implementation for <see cref="QuizCardBLModel"/> model.
    /// </summary>
    internal class TestCardMapperProfile : IManualMapperProfile<QuizCardDALModel, QuizCardBLModel>,
         IManualMapperProfile<QuizCardBLModel, QuizCardDALModel>
    {
        /// <inheritdoc />
        public QuizCardBLModel MapManual(QuizCardDALModel source)
        {
            return new QuizCardBLModel
            {
                TestTitle = source.Title,
                TestQuestions = source.TestQuestions?.Select(x => new TestQuestionModel
                {                    
                    QuestionId = x.QuestionId,
                    TestId = x.QuestionId,
                    
                }).ToList(),
            };
        }

        public QuizCardDALModel MapManual(QuizCardBLModel source)
        {
            return new QuizCardDALModel
            {
                Title = source.TestTitle,
                TestQuestions = source.TestQuestions?.Select(q => new TestQuestion
                {
                    QuestionId = q.QuestionId,
                    TestId = q.TestId,
                }).ToList(),
                Id = source.Id,
            };
        }
    }
}
