using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Lab.Quiz.DAL;

namespace Lab.Quiz.DAL.Entities
{
    public class MultipleAnswerQuestionViewModel
    {
        public MultipleAnswerQuestion SourceQuestion { get; set; }
        public int[] ChosenOptions { get; set; }
    }
}
