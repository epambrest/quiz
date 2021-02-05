using System;
using System.Collections.Generic;
using System.Text;
using Teams.Data;
using Teams.Data.Repositories;

namespace CheckQueuedPrograms
{
    public class ProgramCodeQuestionRepositoryFactory
    {
        public static IProgramCodeQuestionRepository GetRepository(IApplicationDbContext context) 
            => new ProgramCodeQuestionRepository(context as ApplicationDbContext);
    }
}
