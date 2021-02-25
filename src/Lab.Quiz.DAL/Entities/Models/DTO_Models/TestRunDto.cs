using System;
using System.Collections.Generic;
using System.Linq;
using Lab.Quiz.DAL;

namespace Lab.Quiz.DAL.Entities
{
    public class TestRunDto
    {
        public int Id { get; set; }
        public List<AnswerDto> Answers { get; set; }
        public List<TestQuestion> TestQuestions { get; set; }
        public Guid TestId { get; set; }

        public TestRunDto(List<AnswerDto> answers, Guid testId)
        {
            Id = new Random().Next(0, 1000);
            Answers = answers ?? new List<AnswerDto>();
            TestQuestions = new List<TestQuestion>();
            TestId = testId;
        }
    }
}