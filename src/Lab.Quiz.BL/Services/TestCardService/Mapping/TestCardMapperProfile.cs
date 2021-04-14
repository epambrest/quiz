using System.Linq;
using Lab.Quiz.BL.Services.TestCardService.Models;
using Lab.Quiz.Common.Mapping;
using Lab.Quiz.DAL.Entities;

namespace Lab.Quiz.BL.Services.TestCardService.Mapping
{
    /// <summary>
    /// The <see cref="IManualMapperProfile"/> implementation for <see cref="TestCardVModel"/> model.
    /// </summary>
    internal class TestCardMapperProfile : IManualMapperProfile<TestCardModel, TestCardVModel>,
         IManualMapperProfile<TestCardVModel, TestCardModel>
    {
        /// <inheritdoc />
        public TestCardVModel MapManual(TestCardModel source)
        {
            return new TestCardVModel
            {
                TestTitle = source.Title,
                TestQuestions = source.TestQuestions?.Select(x => new TestQuestionModel
                {
                    QuestionId = x.QuestionId,
                    TestId = x.QuestionId
                }).ToList(),
            };
        }

        public TestCardModel MapManual(TestCardVModel source)
        {
            return new TestCardModel
            {
                Title = source.TestTitle,
                TestQuestions = source.TestQuestions?.Select(q => new TestQuestion
                {
                    QuestionId = q.QuestionId,
                    TestId = q.TestId,
                }).ToList(),
            };
        }
    }
}
