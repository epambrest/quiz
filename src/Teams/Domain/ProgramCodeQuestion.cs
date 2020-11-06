using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Teams.Domain
{
    public class ProgramCodeQuestion : Question
    {
        private Dictionary<string, string> inputsOutputsPairs;
        public IReadOnlyDictionary<string, string> InputsOutputsPairs => inputsOutputsPairs;
        public ProgramCodeQuestion(string text) : base(text)
        {

        }
        public ProgramCodeQuestion(string text, Dictionary<string, string> inputsOutputsPairs) : base(text)
        {
            this.inputsOutputsPairs = inputsOutputsPairs;
        }
    }
}
