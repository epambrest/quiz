﻿using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Lab.Quiz.DAL.Entities;
using Lab.Quiz.DAL.Interfaces;

namespace Lab.Quiz.DAL.Repositories
{
    public class MultipleAnswerQuestionRepository : IMultipleAnswerQuestionRepository
    {
        IApplicationDbContext _db;
        public MultipleAnswerQuestionRepository(IApplicationDbContext db)
        {
            _db = db;
        }
        public MultipleAnswerQuestion PickById(Guid Id)
        {
            return _db.MultipleAnswerQuestions.Include(a => a.Answers).Single(q => q.Id == Id);
        }

        public void AddQuestion(MultipleAnswerQuestion question)
        {
            _db.MultipleAnswerQuestions.Add(question);
            _db.SaveChanges();
        }

        public void DeleteQuestionOptionsInDB(MultipleAnswerQuestion question)
        {
            var answers = question.Answers.ToList();

            foreach (var a in answers)
            {
                _db.Entry(a).State = EntityState.Deleted;
            }
            _db.SaveChanges();
        }

        public void UpdateQuestion(MultipleAnswerQuestion question)
        {
            _db.MultipleAnswerQuestions.Update(question);
            _db.SaveChanges();
        }

    }
}