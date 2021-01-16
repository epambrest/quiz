using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace Teams.Domain
{
    public class TestRun : Entity
    {
        public string TestedUserId { get; private set; }
        public Guid TestId { get; private set; }
        public ReadOnlyCollection<Answer> Answers
        {
            get => _answers.AsReadOnly();
            private set => _answers = new List<Answer>(value);
        } 
        private List<Answer> _answers = new List<Answer>();
        public bool InProgress { get; private set; }

        public TestRun(string testedUserId, Guid testId)
        {
            TestedUserId = testedUserId;
            TestId = testId;
            InProgress = true;
        }
        
        public TestRun(string testedUserId, Guid testId, Guid id) : base(id)
        {
            TestedUserId = testedUserId;
            TestId = testId;
            InProgress = true;
        }

        private TestRun()
        {
        }

        public void Finish()
        {
            InProgress = false;
        }

        public void AddAnswer(Answer answer)
        {
            _answers.Add(answer);
        }
    }
}