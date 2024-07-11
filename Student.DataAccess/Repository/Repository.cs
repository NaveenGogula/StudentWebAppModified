using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using StudentWebApp.DataAccess.Data;
using StudentWebApp.DataAccess.Repository.IRepository;

namespace StudentWebApp.DataAccess.Repository
{
    public class Repository<N> : IRepository<N> where N : class
    {
        private readonly ApplicationDBContext _db;
        internal DbSet<N> dbSet;
        public Repository(ApplicationDBContext db)
        {
            _db = db;
            this.dbSet = _db.Set<N>();
            //_db.Student == dbSet
            _db.Departments.Include(x => x.Student).Include(x => x.StudentId);
        }
        public void Add(N entity)
        {
            dbSet.Add(entity);
        }

        public N Get(Expression<Func<N, bool>> filter, string? includeProperties = null)
        {
            IQueryable<N> query = dbSet;
            query = query.Where(filter);
            if (includeProperties != null)
            {
                foreach (var includeprop in includeProperties.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
                {
                    query = query.Include(includeprop);
                }
            }
            return query.FirstOrDefault();
        }

        public IEnumerable<N> GetAll(string? includeProperties = null)    
        {
            IQueryable<N> query = dbSet;
            if(includeProperties != null)
            {
                foreach(var includeprop in  includeProperties.Split(new char[] {','}, StringSplitOptions.RemoveEmptyEntries))
                {
                    query = query.Include(includeprop);
                }
            }
            return query.ToList();
        }

        public void Remove(N entity)
        {
            dbSet.Remove(entity);
        }

        public void RemoveRange(IEnumerable<N> entity)
        {
            dbSet.RemoveRange(entity);
        }
    }
}
