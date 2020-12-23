using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace Teams.Domain
{
    public class Answer : Entity 
    {
        private readonly List<string> _answerOptions = new List<string>();
        public ReadOnlyCollection<string> Answers => _answerOptions.AsReadOnly();
        private string answerText;

        public string AnswerText => answerText;

        public Guid TestQuestionId { get; }
        
        private Answer()
        {
        }

        public Answer(string answer, Guid testQuestionId, Guid id)
        {
            answerText = answer;
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
            answerText = answer;
        }
        public void Add(Guid answer)
        {
            _answerOptions.Add(answer.ToString());
        }
        public void Add(List<Guid> answer)
        {
            if (answer != null)
            {
                foreach (var id in answer)
                {
                    _answerOptions.Add(id.ToString());
                }
            }
        }
    }
}