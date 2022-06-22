using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Interfaces
{
    public interface IRepository<T>
    {
        Task<IEnumerable<T>> GetAll();
        Task<T> GetById(int id);
        Task<int> FindSQL(string query);
        Task<T> Add(T entity);
        Task<T> Update(T entity);
        Task DeleteById(int id);
        Task<int> Save();
    }
}
