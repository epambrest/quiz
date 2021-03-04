using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Teams.Domain
{
    public class SingleSelectionQuestionOption: Entity
    {
        public string Text { get; set; }
        public bool IsAnswer { get; set; }
    }
}
