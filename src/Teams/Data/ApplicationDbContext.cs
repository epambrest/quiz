using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Newtonsoft.Json;
using Teams.Domain;
using Teams.Models;

namespace Teams.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>, IApplicationDbContext
    {
        public DbSet<OpenAnswerQuestion> OpenAnswerQuestions { get; set; }
        public DbSet<Question> Questions { get; set; }
        public DbSet<SingleSelectionQuestion> SingleSelectionQuestions { get; set; }
        public DbSet<MultipleAnswerQuestion> MultipleAnswerQuestions { get; set; }
        public DbSet<Test> Tests { get; set; }
        public DbSet<TestQuestion> TestQuestions { get; set; }
        public DbSet<ProgramCodeQuestion> ProgramCodeQuestions { get; set; }
        public DbSet<Answer> Answers { get; set; }
        public DbSet<TestRun> TestRuns { get; set; }
        public DbSet<QueuedProgram> QueuedPrograms { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.Entity<Answer>().Property(e=>e.AnswerOptions)
                .HasConversion(v => JsonConvert.SerializeObject(v),
                    v => JsonConvert.DeserializeObject<ReadOnlyCollection<Guid>>(v));
            builder.Entity<TestRun>().HasMany(e => e.Answers);
            builder.Entity<QueuedProgram>().ToTable("QueuedPrograms").HasKey("Id");
            builder.Entity<QueuedProgram>().Property(b => b.Id).HasColumnName("Id").HasColumnType("bigint")
                .ValueGeneratedOnAdd();
            builder.Entity<QueuedProgram>().HasOne<ProgramCodeQuestion>().WithMany().HasForeignKey(k => k.QuestionId);
            builder.Entity<QueuedProgram>().Property(b => b.QuestionId).HasColumnName("questionId").HasColumnType("uniqueidentifier");
            builder.Entity<QueuedProgram>().Property(b => b.Program).HasColumnName("program").HasColumnType("nvarchar(max)");
            builder.Entity<QueuedProgram>().Property(b => b.Status).HasColumnName("status").HasColumnType("int");
        }
    }
}
