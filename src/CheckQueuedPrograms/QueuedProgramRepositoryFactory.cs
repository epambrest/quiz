using System;
using System.Collections.Generic;
using System.Text;
using Teams.Data;
using Teams.Data.Repositories;

namespace CheckQueuedPrograms
{
    public class QueuedProgramRepositoryFactory
    {
        public static IQueuedProgramRepository GetRepository(IApplicationDbContext context) 
            => new QueuedProgramRepository(context as ApplicationDbContext);
    }
}
