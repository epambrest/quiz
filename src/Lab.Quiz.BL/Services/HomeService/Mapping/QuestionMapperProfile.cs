using Lab.Quiz.BL.Services.HomeService.Models;
using Lab.Quiz.Common.Mapping;
using Lab.Quiz.DAL.Entities;

namespace Lab.Quiz.BL.Services.HomeService.Mapping
{
    internal class QuestionMapperProfile : IManualMapperProfile<Question, QuestionModel>
    {
        public QuestionModel MapManual(Question source)
        {
            return new QuestionModel()
            {
                Text = source.Text,
            };
        }
    }
}
