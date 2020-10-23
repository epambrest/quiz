﻿using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Teams.Domain;

namespace Teams.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public DbSet<Question> Questions { get; set; }
        public DbSet<SingleSelectionQuestion> SingleSelectionQuestions { get; set; }
        public DbSet<MultipleAnswerQuestion> MultipleAnswerQuestions { get; set; }
        public DbSet<OpenAnswerQuestion> OpenAnswerQuestions { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
    }
}
