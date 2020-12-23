using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations.Schema;

namespace Teams.Domain
{
    public class TestRun : Entity
    {
        public string TestedUserId { get; private set; }
        public Guid TestId { get; private set; }
        public ReadOnlyCollection<Answer> Answers => _answers.AsReadOnly();
        private readonly List<Answer> _answers = new List<Answer>();
        public bool InProgress { get; private set; }
        
        public TestRun(string testedUserId, Guid testId, List<Answer> answers)
        {
            TestedUserId = testedUserId;
            TestId = testId;
            InProgress = true;
            if (answers!= null) _answers = answers;
        }

        private TestRun()
        {
        }

        public void Finish()
        {
            InProgress = false;
        }

        public void Add(Answer answer)
        {
            _answers.Add(answer);
        }
        public void Add(List<Answer> answers)
        {
            if (answers != null) 
                foreach (var a in answers)
                {
                    Add(a);
                }
        }
    }
}