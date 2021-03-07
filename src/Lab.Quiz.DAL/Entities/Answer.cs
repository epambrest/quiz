using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace Lab.Quiz.DAL.Entities
{
    public class Answer : Entity
    {
        public ICollection<Guid> AnswerOptions { get; set; }
        public string AnswerText { get; set; }
        public Guid TestQuestionId { get; set; }

    }
}