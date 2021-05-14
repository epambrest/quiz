using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Lab.Quiz.NewDAL.Models
{
    public enum CardType
    {
        SingleSelectionQuestion, MultipleAnswerQuestion
    }
    public class QuizCard
    {
        public long Id { get; set; }
        [Required]
        public string Title { get; set; }
        [Required]
        public string QuestionText { get; set; }
        [Required]
        public CardType CardType { get; set; }
        public IList<Quiz> Quizzes{ get; set; }
        public IList<CardAnswer> CardAnswers { get; set; }
    }
}
