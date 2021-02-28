using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace Lab.Quiz.DAL.Entities 
{ 
    public class TestRun
    {
        public string TestedUserId { get; private set; }
        public int Id { get; private set; }
        public Guid TestId { get; private set; }
        public ReadOnlyCollection<Answer> Answers
        {
            get => _answers.AsReadOnly();
            private set => _answers = new List<Answer>(value);
        } 
        //private List<Answer> _answers = new List<Answer>();
        public bool InProgress { get; private set; }

        //public TestRun(string testedUserId, Guid testId)
        //{
        //    TestedUserId = testedUserId;
        //    TestId = testId;
        //    InProgress = true;
        //    Id = new Random().Next(1, 1000);
        //}
        
        //public TestRun(string testedUserId, Guid testId, int id)
        //{
        //    TestedUserId = testedUserId;
        //    TestId = testId;
        //    InProgress = true;
        //    Id = id;
        //}

        //private TestRun()
        //{
        //}

        //public void Finish()
        //{
        //    InProgress = false;
        //}

        //public void AddAnswer(Answer answer)
        //{
        //    _answers.Add(answer);
        //}
    }
}