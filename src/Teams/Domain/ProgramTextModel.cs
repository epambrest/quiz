using System;
using System.Collections.Generic;
using Teams.Domain;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Teams.Models
{
    [Table("Queue")]
    public class ProgramTextModel
    {
        [Key]
        [Column(TypeName = "bigint")] public long Id { get; set; }
        [Column("questionId")]public Guid QuestionId { get; set; }
        [Column("program", TypeName = "nvarchar(max)")] public string Program { get; set; }
        [Column("status")]public int Status { get; set; }
    }
}
