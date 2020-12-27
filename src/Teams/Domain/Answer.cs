using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace Teams.Domain
{
    public class Answer : Entity
    {
        public ReadOnlyCollection<Guid> AnswerOptions
        {
            get => _answerOptions.Select(Guid.Parse).ToList().AsReadOnly();
            private set { _answerOptions = value.Select(x => x.ToString()).ToList(); }
        }

        private List<string> _answerOptions = new List<string>();

        public string AnswerText
        {
            get => new string(_answerText);
            private set => _answerText = value;
        }

        private string _answerText = "";
        public Guid TestQuestionId { get; private set; }

        private Answer()
        {
        }

        public Answer(string answer, Guid testQuestionId, Guid id)
        {
            AnswerText = answer;
            Id = id;
            TestQuestionId = testQuestionId;
        }

        public Answer(List<Guid> answers, Guid testQuestionId, Guid id)
        {
            if (answers != null)
            {
                _answerOptions = new List<string>();
                foreach (var i in answers) _answerOptions.Add(i.ToString());
            }

            Id = id;
            TestQuestionId = testQuestionId;
        }

        public void Add(string answer)
        {
            if (AnswerOptions.Count == 0) AnswerText = answer;
        }

        public void Add(Guid answer)
        {
            if (AnswerText == "") _answerOptions.Add(answer.ToString());
        }

        public void Add(List<Guid> answer)
        {
            if (answer == null) return;
            foreach (var id in answer)
                Add(id);
        }
    }
}