using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Teams.Domain;

namespace Teams.Models
{
    public class MultipleQuestionAddModel  
    {
        public string QuestionText { get; set; }
        public IEnumerable<QuestionAnswer> QuestionAnswers { get; set; }
    }

    public class QuestionAnswer
    {
        public string AnswersText { get; set; }
        public bool IsRightAnswer { get; set; }
    }
}

