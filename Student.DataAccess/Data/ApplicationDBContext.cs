using Microsoft.EntityFrameworkCore;
using StudentWebApp.Models.Models.Entities;
using StudentWebApp.Models.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;

namespace StudentWebApp.DataAccess.Data
//namespace StudentWebApp.Models.Entities
{
    public class ApplicationDBContext: IdentityDbContext<IdentityUser>
    {
        public ApplicationDBContext(DbContextOptions options) : base(options)
        {
        }
        public DbSet<Student> Students { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<ApplicationUser> ApplicationUsers {  get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

             //modelBuilder.Entity<Department>().HasData(

             //     new Student
             //     {
             //         Name = "Naveen",
             //         Email= "Naveen@g.com",
             //         Phone= "1234567890",
             //        StudentId =1

             //     },
             //     new Student
             //     {
             //   Name = "Naveen2",
             //         Email = "Naveen2@g.com",
             //         Phone = "1234567890",
             //        StudentId = 2

             //     }
             //     );


            modelBuilder.Entity<Department>().HasData(

                  new Department 
                  {
                    DepartmentId = 1,
                    DepartmentName ="Arts",
                    Description =    "Arts department Students",
                    HOD = "Arts HOD",
                    DepartmentBlock = "A",
                    StudentId = 8,
                    ImageUrl=""
                  },
                  new Department
                  {
                    DepartmentId = 2,
                    DepartmentName = "Science",
                    Description = "Science department Students",
                    HOD = "Science HOD",
                    DepartmentBlock = "B",
                    StudentId = 9,
                     ImageUrl = ""
                  },
                  new Department
                  {
                     DepartmentId = 3,
                     DepartmentName = "Computers",
                     Description = "Computers Science department Students",
                     HOD = "Computers HOD",
                     DepartmentBlock = "C",
                     StudentId = 10,
                      ImageUrl = ""
                  },
                  new Department
                  {
                      DepartmentId = 4,
                      DepartmentName = "Aeronautical",
                      Description = "Aeronautical department Students",
                      HOD = "Aeronautical HOD",
                      DepartmentBlock = "D",
                      StudentId = 11,
                       ImageUrl = ""
                  },
                  new Department
                   {
                       DepartmentId = 5,
                       DepartmentName = "DataScience",
                       Description = "DataScience department Students",
                       HOD = "DataScience HOD",
                       DepartmentBlock = "E",
                       StudentId = 12,
                        ImageUrl = ""
                  }

                );
        }
    }
}
