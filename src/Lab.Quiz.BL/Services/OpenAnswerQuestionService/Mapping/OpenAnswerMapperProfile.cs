using Lab.Quiz.BL.Services.OpenAnswerQuestionService.Models;
using Lab.Quiz.Common.Mapping;
using Lab.Quiz.DAL.Entities;


namespace Lab.Quiz.BL.Services.OpenAnswerQuestionService.Mapping
{
    /// <summary>
    /// The <see cref="IManualMapperProfile"/> implementation for <see cref="OpenAnswerQuestionModel"/> model.
    /// </summary>
    public class OpenAnswerMapperProfile : IManualMapperProfile<OpenAnswerQuestion, OpenAnswerQuestionModel>
    {
        /// <inheritdoc />
        public OpenAnswerQuestionModel MapManual(OpenAnswerQuestion source)
        {
            return new OpenAnswerQuestionModel {
                Answer = source.Answer,
                Question = source.Text,
                Id = source.Id
            };
        }

    }
}
