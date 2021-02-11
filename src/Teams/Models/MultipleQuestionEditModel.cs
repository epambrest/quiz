using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Teams.Models
{
    public class MultipleQuestionEditModel
    {
        public string QuestionText { get; set; }
        public string[] AnswersText { get; set; }
        public bool[] IsRightAnswer { get; set; }
        public Guid Id { get; set; }
    }
}
