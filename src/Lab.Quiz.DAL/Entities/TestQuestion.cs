using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Lab.Quiz.DAL.Entities
{
    public class TestQuestion: Entity
    {
        public Guid TestId { get; set; }
        public QuizCardDALModel Test { get; set; }
        public Guid QuestionId { get; set; }
        public Question Question { get; set; }
    }
}
