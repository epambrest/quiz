using System;
using System.Collections.Generic;
using System.Linq;

namespace Lab.Quiz.DAL.Entities
{
    public class SingleSelectionQuestion : Question
    {
        public ICollection<SingleSelectionQuestionOption> Options { get; set; }

    }
}
