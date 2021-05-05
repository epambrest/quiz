using Lab.Quiz.NewDAL.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Lab.Quiz.NewDAL
{
   public class QuizDBContext : DbContext
    {
        public DbSet<QuizCard> QuizCards { get; set; }
        public DbSet<Models.Quiz> Quizzes { get; set; }
        public DbSet<CardAnswer> CardAnswers { get; set; }
        public QuizDBContext(DbContextOptions<QuizDBContext> options) : base(options)
        {

        }
    }
}
