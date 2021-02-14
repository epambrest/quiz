using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Teams.Models
{
    public class MultipleQuestionEditModel
    {
        public string QuestionText { get; set; }
        public ICollection<QuestionAnswer> QuestionAnswers { get; set; }
        public Guid Id { get; set; }
    }
}
