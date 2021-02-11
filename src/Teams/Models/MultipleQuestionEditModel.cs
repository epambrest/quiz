using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Teams.Models
{
    public class MultipleQuestionEditModel
    {
        public string QuestionText { get; set; }
        public string[] TextArray { get; set; }
        public bool[] CheckboxValueArray { get; set; }
        public Guid id { get; set; }
    }
}
