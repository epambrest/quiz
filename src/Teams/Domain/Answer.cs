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
            get => _answerOptions.ToList().AsReadOnly();
            private set { _answerOptions = value.ToList(); }
        }

        private List<Guid> _answerOptions = new List<Guid>();

        public string AnswerText
        {
            get => new string(_answerText);
            private set => _answerText = value;
        }
        private string _answerText = "";
        public Guid TestQuestionId { get; private set; }
        public TestRun TestRun { get; private set; }
        public Guid TestRunId { get; private set; }

        private Answer()
        {
        }

        public Answer(Guid testQuestionId, Guid id)
        {
            if (_answerOptions.Count == 0)
            {
                Id = id;
                TestQuestionId = testQuestionId;
            }
        }

        public void Add(string answer)
        {
            if (AnswerOptions.Count == 0) AnswerText = answer;
        }

        public void Add(Guid answer)
        {
            if (AnswerText == "") _answerOptions.Add(answer);
        }

        public void Add(List<Guid> answer)
        {
            foreach (var id in answer) Add(id);
        }
    }
}