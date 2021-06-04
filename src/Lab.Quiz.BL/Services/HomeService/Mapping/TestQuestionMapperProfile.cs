using Lab.Quiz.BL.Services.TestCardService.Models;
using Lab.Quiz.Common.Mapping;
using Lab.Quiz.DAL.Entities;

namespace Lab.Quiz.BL.Services.HomeService.Mapping
{
    internal class TestQuestionMapperProfile : IManualMapperProfile<TestQuestion, TestQuestionModel>
    {
        public TestQuestionModel MapManual(TestQuestion source)
        {
            return new TestQuestionModel
            {
                TestId = source.TestId,
                QuestionId = source.QuestionId,
                QuestionType = source.QuestionType.ToString(),
                Id = source.Id.ToString(),
            };
        }
    }
}
