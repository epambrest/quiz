using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace Teams.Domain
{
    public class Answer : Entity
    {
        public ICollection<Guid> AnswerOptions { get; set; }
        public string AnswerText { get; set; }
        public Guid TestQuestionId { get; set; }

    }
}