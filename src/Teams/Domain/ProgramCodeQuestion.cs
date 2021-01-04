using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Teams.Domain
{
    public class ProgramCodeQuestion : Question
    {
        private List<Data.CodeTester.Test> tests;
        public IReadOnlyCollection<Data.CodeTester.Test> GetTests => tests.ToList();
        public ProgramCodeQuestion(string text) : base(text)
        {

        }
    }
}
