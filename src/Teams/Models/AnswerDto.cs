using System;
using System.Collections.Generic;
using Teams.Domain;

namespace Teams.Models
{
    public class AnswerDto : Entity
    {
        public List<Guid> AnswerOptions { get; set; }
        public string AnswerText { get; set; }
        public Guid TestQuestionId { get; set; }

        public AnswerDto(List<Guid> answerOptions, string answerText, Guid testQuestionId)
        {
            AnswerOptions = answerOptions;
            AnswerText = answerText;
            TestQuestionId = testQuestionId;
        }
    }
}