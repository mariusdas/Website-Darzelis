using System.Collections.Generic;
using System.Linq;

namespace Darzelis.Data.Contracts
{
    public interface IRepository<T> where T : class
    {
       
        IQueryable<T> GetAll();       
        T GetById(int id);
        void Add(T entity);
        void Update(T entity);
        void Delete(T entity);
        void Delete(int id);
        IList<T> GetAllIncludeRequest();

    }
}
