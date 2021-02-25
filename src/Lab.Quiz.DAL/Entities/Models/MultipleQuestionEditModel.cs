﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Lab.Quiz.DAL.Entities
{
    public class MultipleQuestionEditModel
    {
        public string QuestionText { get; set; }
        public IEnumerable<QuestionAnswer> QuestionAnswers { get; set; }
        public Guid Id { get; set; }
    }
}
