using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Teams.Domain
{
    public class OpenAnswerQuestionOption : Entity
    {
        public string AnswerText { get; set; }
        //public OpenAnswerQuestion OpenAnswerQuestion;
        public OpenAnswerQuestionOption(string AnswerText)
        {
            this.AnswerText = AnswerText;
        }
        //public OpenAnswerQuestionOption()
        //{

        //}
    }
}
