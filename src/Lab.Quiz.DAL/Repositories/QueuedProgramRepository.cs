﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Lab.Quiz.DAL.Entities;
using Lab.Quiz.DAL.Interfaces;

namespace Lab.Quiz.DAL.Repositories
{
    public class QueuedProgramRepository : IQueuedProgramRepository
    {
        private ApplicationDbContext _db;
        public QueuedProgramRepository(ApplicationDbContext db)
        {
            _db = db;
        }

        public void Add(Guid id, string text)
        {
            throw new NotImplementedException();
        }
    }
}
