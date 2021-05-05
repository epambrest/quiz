using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab.Quiz.NewDAL.Repositories
{
    public class Repository<T> : IRepository<T> where T : class
    {
        protected QuizDBContext context;

        public Repository(QuizDBContext context)
        {
            this.context = context;
        }
        public virtual ValueTask<T> Get(long id)
        {
            return context.Set<T>().FindAsync(id);
        }

        public virtual IQueryable<T> GetAll()
        {
            return context.Set<T>();
        }

        public virtual Task Create(T newDataObject)
        {
            context.Add(newDataObject);
            return context.SaveChangesAsync();
        }

        public virtual Task Delete(long id)
        {
            context.Remove(Get(id));
            return context.SaveChangesAsync();
        }

        public virtual Task Update(T changedDataObject)
        {
            context.Update<T>(changedDataObject);
            return context.SaveChangesAsync();
        }
    }
}
