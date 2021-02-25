﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Lab.Quiz.DAL.Entities
{
    public class OpenAnswerQuestionModel
    {
        public string Question { get; set; }
        public string Answer { get; set; }
        public Guid Id { get; set; }
        public bool IsAnswer { get; set; }
    }
}
