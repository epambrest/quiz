using System.Collections.Generic;
using System.Linq;
using Lab.Quiz.BL.Services.TestService.Models;
using Lab.Quiz.Common.Mapping;
using Lab.Quiz.DAL.Entities;

namespace Lab.Quiz.BL.Services.TestService.Mapping
{
    /// <summary>
    /// The <see cref="IManualMapperProfile"/> implementation for <see cref="TestCardModel"/> model.
    /// </summary>
    internal class TestCardMapperProfile : IManualMapperProfile<Test, TestCardModel>
    {
        /// <inheritdoc />
        public TestCardModel MapManual(Test source)
        {
            return new TestCardModel
            {
                TestTitle = source.Title,
                TestQuestions = source.TestQuestions?.Select(x => new TestQuestionModel
                {
                    QuestionId = x.QuestionId,
                    TestId = x.QuestionId
                }).ToList(),
            };
        }
    }
}
