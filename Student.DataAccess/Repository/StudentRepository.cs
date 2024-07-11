using StudentWebApp.DataAccess.Data;
using StudentWebApp.DataAccess.Repository.IRepository;
using StudentWebApp.Models.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace StudentWebApp.DataAccess.Repository
{
    public class StudentRepository : Repository<Student>,IStudentRepository
    {
        private ApplicationDBContext _db;
        public StudentRepository(ApplicationDBContext db) : base(db)
        {
            _db = db;
        }
        public void Update(Student obj)
        {
           _db.Students.Update(obj);
        }
    }
}
