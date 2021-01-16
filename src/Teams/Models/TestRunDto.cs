using System;
using System.Collections.Generic;
using System.Linq;
using Teams.Domain;

namespace Teams.Models
{
    public class TestRunDto
    {
        public Guid Id { get; set; }
        public List<AnswerDto> Answers { get; set; }
        public List<TestQuestion> TestQuestions { get; set; }
        public Guid TestId { get; set; }

        public TestRunDto(List<AnswerDto> answers, List<TestQuestion> questions)
        {
            Id = Guid.NewGuid();
            Answers = answers ?? new List<AnswerDto>();
            TestQuestions = questions ?? new List<TestQuestion>();
            TestId = questions.ElementAt(0).TestId;
        }
    }
}