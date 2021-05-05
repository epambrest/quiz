using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Lab.Quiz.NewDAL.Models
{
    public class CardAnswer
    {
        public long Id { get; set; }
        [Required]
        public string AnswerText { get; set; }
        [Required]
        public bool IsRight { get; set; }
        public IList<QuizCard> QuizCards { get; set; }
    }
}
