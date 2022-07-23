using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HolidaysApplication.Repository.IRepository
{
    public interface IGenericRepository<T> where T : class
    {
        void Add(T entity);
        IEnumerable<T> GetAll();
    }
}
