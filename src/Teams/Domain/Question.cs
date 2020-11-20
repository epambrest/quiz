using System.Collections.Generic;

namespace Teams.Domain
{
    public class Question : Entity
    {
        public string QuestionText { get; private set; }
        public Answers CorrectAnswers { get; private set; }

        public Question(string questionText)
        {
            QuestionText = questionText;
        }

        public void SetAnswer(ICollection<string> answerText)
        {
            CorrectAnswers = new Answers(answerText);
        }
    }
}
