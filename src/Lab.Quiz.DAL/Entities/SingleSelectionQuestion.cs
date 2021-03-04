using System;
using System.Collections.Generic;
using System.Linq;

namespace Teams.Domain
{
    public class SingleSelectionQuestion : Question
    {
        public ICollection<SingleSelectionQuestionOption> Options { get; set; }

    }
}
