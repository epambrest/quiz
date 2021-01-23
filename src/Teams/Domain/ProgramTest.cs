using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Teams.Domain
{
    public class ProgramTest
    {
        [Key]
        public long Id { get; set; }
        public string InputTest { get; set; }
        public string OutputTest { get; set; }

        public Question Question { get; set; }
        public Guid QuestionId { get; set; }
    }
}
