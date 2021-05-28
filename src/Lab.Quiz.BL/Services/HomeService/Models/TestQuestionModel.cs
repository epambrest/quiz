using Lab.Quiz.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Lab.Quiz.BL.Services.HomeService.Model
{
    public class TestQuestionModel : TestCardService.Models.TestQuestionModel
    {
        public QuestionType QuestionType { get; set; }
    }
}
