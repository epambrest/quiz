using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Teams.Models;

namespace Teams.Domain
{
    public class Test : Entity
    {
        public string Title { get; set; }
        public ICollection<TestQuestion> TestQuestions { get; set; }
    }
}
