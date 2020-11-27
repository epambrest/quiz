using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using Teams.Domain;

namespace Teams.Models
{
    public class QuestionViewModel : Entity
    {
        [ForeignKey("Test Run")] public TestRun TestRun { get; set; }
        public Question Question { get; set; }
    }
}
