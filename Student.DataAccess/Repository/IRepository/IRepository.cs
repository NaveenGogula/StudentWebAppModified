using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace StudentWebApp.DataAccess.Repository.IRepository
{
    public interface IRepository<N> where N : class
    {
        //N -Student

        //Returns: An IEnumerable<T> which is a collection of entities of type T
        IEnumerable<N> GetAll(string? includeProperties = null);

        //Returns: An entity of type T that matches the condition specified by the filter
        N Get(Expression<Func<N, bool>> filter, string? includeProperties = null);
        void Add(N entity);
        void Remove(N entity);
        void RemoveRange(IEnumerable<N> entity);
    }
}
