using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Lab.Quiz.DAL.Interfaces;
using Lab.Quiz.DAL.Entities;

namespace Lab.Quiz.DAL.Repositories
{
    public class OpenAnswerQuestionRepository : IOpenAnswerQuestionRepository
    {
        IApplicationDbContext context;
        public OpenAnswerQuestionRepository(IApplicationDbContext context)
        {
            this.context = context;
        }
        public OpenAnswerQuestion Get(Guid id)
        {
            return context.OpenAnswerQuestions.FirstOrDefault(x => x.Id == id);
        }
    }
}
