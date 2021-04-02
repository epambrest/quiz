using System.Collections.Generic;

namespace Lab.Quiz.BL.Services.TestService.Models
{
    public class TestCardModel
    {
        public string TestTitle { get; set; }

        public ICollection<TestQuestionModel> TestQuestions { get; set; }
    }
}
