using System.Collections.Generic;
using System.Linq;
using Lab.Quiz.BL.Services.TestCardService.Models;
using Lab.Quiz.Common.Mapping;
using Lab.Quiz.DAL.Entities;

namespace Lab.Quiz.BL.Services.TestCardService.Mapping
{
    internal class TestCardCollectionMapperProfile : IManualMapperProfile<ICollection<Test>, ICollection<TestCardModel>>
    {
        public ICollection<TestCardModel> MapManual(ICollection<Test> source)
        {
            return source.Select(s => new TestCardModel
            {
                TestTitle = s.Title,
                TestQuestions = s.TestQuestions?.Select(q => new TestQuestionModel
                {
                    QuestionId = q.QuestionId,
                    TestId = q.QuestionId
                }).ToList(),
            }).ToList();
        }
    }
}
