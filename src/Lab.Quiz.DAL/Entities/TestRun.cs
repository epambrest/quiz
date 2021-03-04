using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace Teams.Domain
{
    public class TestRun
    {
        public string TestedUserId { get; set; }
        public int Id { get; set; }
        public Guid TestId { get; set; }
        public ICollection<Answer> Answers { get; set; }
        public bool InProgress { get; set; }

    }
}