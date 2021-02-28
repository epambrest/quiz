using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Lab.Quiz.DAL.Interfaces.Repositories
{
    public interface IRepository<TEntity> where TEntity : class
    {
        public TEntity GetById(Guid id);
        public Task<TEntity> GetByIdAsync(Guid id);
        public IEnumerable<TEntity> GetAll();
        public Task<IEnumerable<TEntity>> GetAllAsync();
        public void Add(TEntity entity);
        public void AddAsync(TEntity entity);
        public void Update(TEntity entity);
    }
}
