﻿using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;
using Lab.Quiz.DAL.Interfaces;
using Lab.Quiz.DAL.Entities;
using System.Collections.Generic;

namespace Lab.Quiz.DAL.Repositories
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : class 
    {
        DbSet<TEntity> Entities { get; set; }
        public Repository(DbSet<TEntity> entities)
        {
            Entities = entities;
        }

        public async Task<TEntity> GetByIdAsync(Guid id)
        {
            return await Entities.FindAsync(id);
        }

        public IQueryable<TEntity> GetAll()
        {
            return Entities;
        }

        public void Add(TEntity entity)
        {
            Entities.Add(entity);
        }

        public void Update(TEntity entity)
        {
            Entities.Update(entity);
        }

        public void Delete(TEntity entity)
        {
            Entities.Remove(entity);
        }
    }
}
