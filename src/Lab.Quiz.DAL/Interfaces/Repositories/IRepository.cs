using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;

namespace Lab.Quiz.DAL.Interfaces
{
    public interface IRepository<TEntity> where TEntity : class
    {
        TEntity GetById(Guid id);
        Task<TEntity> GetByIdAsync(Guid id);
        IQueryable<TEntity> GetAll();
        void Add(TEntity entity);
        void AddAsync(TEntity entity);
        void Update(TEntity entity);
        void Delete(TEntity entity);
        
    }
}
