using StudentWebApp.Models.Models;
using StudentWebApp.Models.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentWebApp.DataAccess.Repository.IRepository
{
    public interface IStudentRepository : IRepository<Student>
    {
        void Add(Student obj);
        void Update(Student obj);
        //void Save();
        //Task SaveChangesAsync();
        //Task<string?> ToListAsync();
        //Task<string?> FindAsync(Guid id);
        //object AsNoTracking();
        //Task Remove(Func<object, bool> value);
        //Task FirstOrDefault(Func<object, bool> value);
    }
}
