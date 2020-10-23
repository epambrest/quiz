using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Teams.Domain
{
    public class OpenAnswerQuestion : Question
    {
        public OpenAnswerQuestionOption Answer { get; set; }
        public OpenAnswerQuestion(string Text) : base(Text)
        {

        }
        public OpenAnswerQuestion(string Text, string AnswerText) : base(Text)
        {
            Answer = new OpenAnswerQuestionOption(AnswerText);
        }
    }
}
