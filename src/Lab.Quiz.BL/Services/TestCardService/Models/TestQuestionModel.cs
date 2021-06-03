using System;

namespace Lab.Quiz.BL.Services.TestCardService.Models
{
    public class TestQuestionModel
    {
        public Guid TestId { get; set; }

        public Guid QuestionId { get; set; }

        public string Id { get; set; }

        public string QuestionType { get; set; }
    }
}