using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Lab.Quiz.DAL.Entities
{
    public class QueuedProgram
    {
        public long Id { get; set; }
        public Guid QuestionId { get; set; }
        public string Program { get; set; }
        public int Status { get; set; }
    }
}
