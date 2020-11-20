namespace Teams.Domain
{
    public class OpenAnswerQuestion : Question
    {

        public string Answer { get; private set; }

        public OpenAnswerQuestion(string questionText, string answer) : base(questionText)
        {
            Answer = answer;
        }
        public bool IsCorrectAnswer(string answer)
        {
            answer = answer.Trim();
            return answer == Answer;
        }


    }
}
