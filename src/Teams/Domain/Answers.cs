using System.Collections.Generic;

namespace Teams.Domain
{
    public class Answers : Entity
    {
        public ICollection<string> AnswersText { get; private set; }

        public Answers()
        {
        }

        public Answers(ICollection<string> questionText)
        {
            AnswersText = questionText;
        }
    }
}