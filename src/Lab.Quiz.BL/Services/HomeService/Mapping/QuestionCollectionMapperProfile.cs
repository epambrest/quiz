using System.Collections.Generic;
using System.Linq;
using Lab.Quiz.BL.Services.HomeService.Models;
using Lab.Quiz.Common.Mapping;
using Lab.Quiz.DAL.Entities;

namespace Lab.Quiz.BL.Services.HomeService.Mapping
{
    internal class QuestionCollectionMapperProfile : IManualMapperProfile<ICollection<Question>, ICollection<QuestionModel>>
    {
        public ICollection<QuestionModel> MapManual(ICollection<Question> source)
        {
            return source.Select(s => new QuestionModel()
            {
                Text = s.Text,
            }).ToList();
        }
    }
}