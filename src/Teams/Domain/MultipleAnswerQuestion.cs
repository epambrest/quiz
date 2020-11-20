using System;
using System.Collections.Generic;
using System.Linq;

namespace Teams.Domain
{
    public class MultipleAnswerQuestion : Question
    {
        private List<MultipleAnswerQuestionOption> answers;
        public IReadOnlyCollection<MultipleAnswerQuestionOption> Answers => answers.ToList();
        public MultipleAnswerQuestion(string questionText) : base(questionText)
        {
            if (string.IsNullOrEmpty(questionText)) throw new ArgumentException("A question must have non-empty title");
        }
        public MultipleAnswerQuestion(string questionText, List<MultipleAnswerQuestionOption> answers) : base(questionText)
        {
            if (answers.Count == 0) throw new ArgumentException("A question must have at least one possible answer");
            if (string.IsNullOrEmpty(questionText)) throw new ArgumentException("A question must have non-empty title");
            this.answers = answers;
        }
        public Guid[] GetRightAnswersIds()
        {
            return GetRightAnswers().Select(a => a.Id).ToArray();
        }
        public MultipleAnswerQuestionOption[] GetRightAnswers()
        {
            return Answers.Where(a => a.IsRight).ToArray();
        }
    }
}
