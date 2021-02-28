using System;
using System.Collections.Generic;
using Teams.Data;
using System.Linq;
using System.Security.Cryptography;
using System.Net.Mime;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;

namespace Lab.Quiz.DAL.Entities
{
    public class MultipleAnswerQuestion : Question
    {
        //private List<MultipleAnswerQuestionOption> _answers;
        //public IReadOnlyCollection<MultipleAnswerQuestionOption> Answers => _answers;
        //public MultipleAnswerQuestion(string text) : base(text)
        //{
        //    if (string.IsNullOrEmpty(text)) throw new ArgumentException("A question must have non-empty title");
        //}
        //public MultipleAnswerQuestion(string text, List<MultipleAnswerQuestionOption> answers) : base(text)
        //{
        //    if (answers.Count == 0) throw new ArgumentException("A question must have at least one possible answer");
        //    if (string.IsNullOrEmpty(text)) throw new ArgumentException("A question must have non-empty title");
        //    _answers = answers;
        //}
        //public Guid[] GetRightAnswersIds()
        //{
        //    return GetRightAnswers().Select(a => a.Id).ToArray();
        //}
        //public MultipleAnswerQuestionOption[] GetRightAnswers()
        //{
        //    return Answers.Where(a => a.IsRight).ToArray();
        //}

        //public void EditQuestion(string questionText, List<MultipleAnswerQuestionOption> answers)
        //{
        //    Text = questionText;
        //    _answers = answers;
        //}
    }
}
