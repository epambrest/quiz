using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using Teams.Domain;

namespace Teams.Data
{
    public interface IApplicationDbContext
    {
        public DbSet<Question> Questions { get; set; }
        public DbSet<SingleSelectionQuestion> SingleSelectionQuestions { get; set; }
        public DbSet<MultipleAnswerQuestion> MultipleAnswerQuestions { get; set; }
        public DbSet<OpenAnswerQuestion> OpenAnswerQuestions { get; set;}
        int SaveChanges();
        EntityEntry Entry(Object entity);
    }
}
