using System;
using System.Collections.Generic;

namespace Lab.Quiz.BL.Services.TestCardService.Models
{
    public class QuizCardBLModel
    {
        public Guid Id { get; set; }

        public string TestTitle { get; set; }

        public ICollection<TestQuestionModel> TestQuestions { get; set; }
    }
}
