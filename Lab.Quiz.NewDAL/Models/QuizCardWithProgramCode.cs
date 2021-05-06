using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Lab.Quiz.NewDAL.Models
{
    public class QuizCardWithProgramCode
    {
        public long Id { get; set; }
        [Required]
        public string Title { get; set; }
        [Required]
        public string QuestionText { get; set; }
        public string IncomingData { get; set; }
        [Required]
        public string ExpectedOutgoingData { get; set; }
        public TimeSpan MaximumExecutionTime { get; set; }
        public IList<Quiz> Quizzes { get; set; }
    }
}
