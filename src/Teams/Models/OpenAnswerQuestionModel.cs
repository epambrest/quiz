using System;

namespace Teams.Models
{
    public class OpenAnswerQuestionModel
    {
        public string Question { get; set; }
        public string Answer { get; set; }
        public Guid Id { get; set; }
        public bool IsAnswer { get; set; }
    }
}
