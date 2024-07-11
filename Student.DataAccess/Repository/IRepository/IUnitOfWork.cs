using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentWebApp.DataAccess.Repository.IRepository
{
    public interface IUnitOfWork
    {
        IStudentRepository StudentR { get; }

        IDepartmentRepository DepartmentR { get; }

        void Save();
    }
}
