using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bouchon.API.Db
{
    public interface IRepository<T> where T : class
    {
        Task<bool> Add(T entity);

        Task<bool> Delete(int id);

        Task<IEnumerable<T>> GetAll();

        Task<T> GetById(int id);

        IQueryable<T> Query();

        Task<bool> Update(T entity);
    }
}
