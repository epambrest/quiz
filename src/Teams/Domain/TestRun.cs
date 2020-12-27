using System;
using System.Collections.Generic;

namespace Teams.Domain
{
    public class TestRun : Entity
    {
        public string TestedUserId { get; private set; }
        public Guid TestId { get; private set; }
        public List<Guid> AnswersIds { get; private set; }
        public bool InProgress { get; private set; }

        public TestRun(string testedUserId, Guid testId, List<Guid> answersIds)
        {
            AnswersIds = answersIds ?? new List<Guid>();
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

        public void Add(Guid answer)
        {
            AnswersIds.Add(answer);
        }

        public void Add(List<Guid> answers)
        {
            AnswersIds.AddRange(answers);
        }
    }
}