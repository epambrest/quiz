using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Lab.Quiz.NewDAL.Models
{
    public class Quiz
    {
        public long Id { get; set; }
        [Required]
        public string Title { get; set; }
        public string Description { get; set; }
        public IList<QuizCard> QuizCards { get; set; }
        public IList<QuizCardWithProgramCode> QuizCardsWithProgramCode { get; set; }
    }
}
