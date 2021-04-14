using System.Collections.Generic;
using System.Linq;
using Lab.Quiz.BL.Services.TestCardService.Models;
using Lab.Quiz.Common.Mapping;
using Lab.Quiz.DAL.Entities;

namespace Lab.Quiz.BL.Services.TestCardService.Mapping
{
    internal class TestCardCollectionMapperProfile : IManualMapperProfile<ICollection<TestCardModel>, ICollection<TestCardVModel>>
    {
        public ICollection<TestCardVModel> MapManual(ICollection<TestCardModel> source)
        {
            return source.Select(s => new TestCardVModel
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
