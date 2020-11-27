using System.Collections.Generic;

namespace Teams.Domain
{
    public class Question : Entity
    {
        public string Text { get; set; }
        public Answers CorrectAnswers { get; private set; }

        public Question(string text)
        {
            Text = text;
        }

        public void SetAnswer(string answerText)
        {
            CorrectAnswers = new Answers(answerText);
        }
    }
}
