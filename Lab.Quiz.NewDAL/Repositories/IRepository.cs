using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab.Quiz.NewDAL.Repositories
{
    public interface IRepository<T> where T : class
    {
        ValueTask<T> Get(long id);
        IQueryable<T> GetAll();
        Task Create(T newDataObject);
        Task Update(T changedDataObject);
        Task Delete(long id);
    }
}
