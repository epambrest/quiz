using System;
using System.Collections.Generic;
using Teams.Domain;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Teams.Models
{
    public class QueuedProgram
    {
        public long Id { get; set; }
        public Guid QuestionId { get; set; }
        public string Program { get; set; }
        public int Status { get; set; }
    }
}
