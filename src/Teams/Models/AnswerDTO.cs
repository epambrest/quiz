using System;
using System.Collections.Generic;
using Teams.Domain;

namespace Teams.Models
{
    public class AnswerDTO : Entity
    {
        public List<string> Answers { get; set; }
        public bool IsOption { get; set; }
        public Guid TestRunId { get; set; }
        public Guid TestQuestionId { get; set; }

        public AnswerDTO()
        {
            Id = Guid.NewGuid();
        }

        public AnswerDTO(List<string> answers, bool isOption, Guid id, Guid testRunId, Guid testQuestionId)
        {
            Answers = answers;
            IsOption = isOption;
            Id = id;
            TestRunId = testRunId;
            TestQuestionId = testQuestionId;
        }
    }
}