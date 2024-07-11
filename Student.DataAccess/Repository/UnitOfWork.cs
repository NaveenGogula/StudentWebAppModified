using StudentWebApp.DataAccess.Data;
using StudentWebApp.DataAccess.Repository.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentWebApp.DataAccess.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private ApplicationDBContext _db;
        public IStudentRepository StudentR { get; private set; }
        public IDepartmentRepository DepartmentR { get; private set; }
        public UnitOfWork(ApplicationDBContext db)
        {
            _db = db;
            StudentR = new StudentRepository(_db);
            DepartmentR = new DepartmentRepository(_db);
        }
        public void Save()
        {
            _db.SaveChanges();
        }
    }
}
