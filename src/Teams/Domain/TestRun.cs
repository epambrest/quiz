using System;
using System.Collections.Generic;
using System.Linq;

namespace Teams.Domain
{
    public class TestRun : Entity
    {
        public string TestedUserId { get; private set; }
        public Guid TestId { get; private set; }
        public List<Guid> AnswersIds { get; private set; }
        public List<Answer> Answers { get; private set; }
        public bool InProgress { get; private set; }

        public TestRun(string testedUserId, Guid testId)
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

        public void AddAnswer(string answerText, Guid testQuestionId)
        {
            var existingAnswer = Answers.FirstOrDefault(a => a.TestQuestionId == testQuestionId);
            if (existingAnswer == null)
            {
                Answer answer = new Answer(testQuestionId, Guid.NewGuid());
                answer.Add(answerText);
                AnswersIds.Add(answer.Id);
            }
            else
            {
                existingAnswer.Add(answerText);
            }
        }
        
        public void AddAnswer(Guid answerId, Guid testQuestionId)
        {
            var existingAnswer = Answers.FirstOrDefault(a => a.TestQuestionId == testQuestionId);
            if (existingAnswer == null)
            {
                Answer answer = new Answer(testQuestionId, Guid.NewGuid());
                answer.Add(answerId);
                AnswersIds.Add(answer.Id);
            }
            else
            {
                existingAnswer.Add(answerId);
            }
        }
        
        public void AddAnswer(List<Guid> answersIds, Guid testQuestionId)
        {
            var existingAnswer = Answers.FirstOrDefault(a => a.TestQuestionId == testQuestionId);
            if (existingAnswer == null)
            {
                Answer answer = new Answer(testQuestionId, Guid.NewGuid());
                answer.Add(answersIds);
                AnswersIds.Add(answer.Id);
            }
            else
            {
                existingAnswer.Add(answersIds);
            }
        }
    }
}