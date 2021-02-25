using System;
using System.Collections.Generic;
using Lab.Quiz.DAL;

namespace Lab.Quiz.DAL.Entities
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