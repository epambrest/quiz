﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Teams.Models
{
    public class MultipleQuestionAddModel  
    {
        public string QuestionText { get; set; }
        public string[] TextArray { get; set; }
        public bool[] CheckboxValueArray { get; set; }

    }
}
