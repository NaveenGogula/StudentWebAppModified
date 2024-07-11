using StudentWebApp.DataAccess.Data;
using StudentWebApp.DataAccess.Repository.IRepository;
using StudentWebApp.Models.Models;
using StudentWebApp.Models.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace StudentWebApp.DataAccess.Repository
{
    public class DepartmentRepository : Repository<Department>, IDepartmentRepository
    {
        private ApplicationDBContext _db;
        public DepartmentRepository(ApplicationDBContext db) : base(db)
        {
            _db = db;
        }
        public void Update(Department obj)
        {
           _db.Departments.Update(obj);
        }
    }
}
