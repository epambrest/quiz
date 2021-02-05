using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Teams.Domain
{
    public class ProgramCodeQuestion : Question
    {
        public ProgramCodeQuestion(string text) : base(text)
        {

        }
        public ProgramCodeQuestion(string text, IEnumerable<CodeTester.Test> tests) : base(text)
        {
            this.tests = new List<CodeTester.Test>(tests);
        }
        private List<CodeTester.Test> tests;
        public IEnumerable<CodeTester.Test> GetTests => tests;
    }
}