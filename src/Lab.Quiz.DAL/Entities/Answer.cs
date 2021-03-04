using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace Lab.Quiz.DAL.Entities
{
    public class Answer : Entity
    {
        public ReadOnlyCollection<Guid> AnswerOptions
        {
            get => _answerOptions.AsReadOnly();
            private set => _answerOptions = new List<Guid>(value);
        }
        private List<Guid> _answerOptions = new List<Guid>();

        public string AnswerText { get; }
        public Guid TestQuestionId { get; }

        public Answer()
        {
        }

        public Answer(Guid testQuestionId, string answerText)
        {
            TestQuestionId = testQuestionId;
            AnswerText = answerText;
        }

        public Answer(Guid testQuestionId, IEnumerable<Guid> optionsIds)
        {
            TestQuestionId = testQuestionId;
            _answerOptions = optionsIds.ToList();
        }
    }
}