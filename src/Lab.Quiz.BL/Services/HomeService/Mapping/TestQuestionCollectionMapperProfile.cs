using Lab.Quiz.BL.Services.TestCardService.Models;
using Lab.Quiz.Common.Mapping;
using Lab.Quiz.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Lab.Quiz.BL.Services.HomeService.Mapping
{
    internal class TestQuestionCollectionMapperProfile : IManualMapperProfile<ICollection<TestQuestion>, ICollection<TestQuestionModel>>
    {
        public ICollection<TestQuestionModel> MapManual(ICollection<TestQuestion> source)
        {
            return source.Select(s => new TestQuestionModel
            {
                TestId = s.TestId,
                QuestionId = s.QuestionId,
                QuestionType = s.QuestionType.ToString(),
                Id = s.Id.ToString(),
            }).ToList();
        }
    }
}
