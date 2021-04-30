using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace Lab.Quiz.DAL.Entities
{
    public class Question : Entity
    {
        public string Text { get; set; }
        public ICollection<TestQuestion> TestQuestions { get; set; }
        public QuestionType QuestionType { get; set; }
    }

    public enum QuestionType
    {
        SingleSelectionQuestion,
        MultipleAnswerQuestion,
        OpenAnswerQuestion,
        ProgramCodeQuestion
    }
}
