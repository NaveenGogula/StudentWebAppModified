using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using StudentWebApp.DataAccess.Data;
using StudentWebApp.DataAccess.Repository.IRepository;
using StudentWebApp.Models;
using StudentWebApp.Models.Models.Entities;
using StudentWebApp.Utility;
//using System.ComponentModel.DataAnnotations;

namespace StudentWebApp.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = SD.Role_Admin)]
    public class StudentsController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public StudentsController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Add(AddStudentViewModel viewModel)
        {

            if (ModelState.IsValid)
            {
                var student = new Student
                {
                    Name = viewModel.Name,
                    Email = viewModel.Email,
                    Phone = viewModel.Phone,
                    Subscribed = viewModel.Subscribed,
                };
                _unitOfWork.StudentR.Add(student);
                _unitOfWork.Save();
                TempData["success"] = "Student created sucessfully";
                return RedirectToAction("List", "Students");
            }
            return View();
        }

        //Above Add Method to save student can be written in this way as well
        //public async Task<IActionResult> Add(Student AnyUserDefinedName)
        //{
        //    await dbContext.Students.AddAsync(AnyUserDefinedName);
        //    await dbContext.SaveChangesAsync();
        //    return RedirectToAction("List", "Students");
        //}

        [HttpGet]
        public IActionResult List()
        {
            var students11 = _unitOfWork.StudentR.GetAll();

            return View(students11);
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var student = _unitOfWork.StudentR.Get(x => x.StudentId == id);

            return View(student);
        }
        [HttpPost]
        public IActionResult Edit(StudentWebApp.Models.Models.Entities.Student viewMode)
        {
            var student = _unitOfWork.StudentR.Get(x => x.Id == viewMode.Id);

            if (student is not null)
            {
                student.Name = viewMode.Name;
                student.Email = viewMode.Email;
                student.Phone = viewMode.Phone;
                student.Subscribed = viewMode.Subscribed;

                _unitOfWork.Save();
                TempData["success"] = "Student Edited Sucessfully";
            }
            return RedirectToAction("List", "Students");
        }

        //Above Edit Method can be wiitten in this way as well
        //public IActionResult Edit1(Student AnyName)
        //{
        //    dbContext.Students.Update(AnyName);
        //    dbContext.SaveChanges();
        //    TempData["success"] = "Student Edited sucessfully";
        //    return RedirectToAction("List", "Students");
        //}


        [HttpPost]
        public IActionResult Delete(StudentWebApp.Models.Models.Entities.Student viewModel)
        {
            var student = _unitOfWork.StudentR.Get(x => x.StudentId == viewModel.StudentId);
            if (student is not null)
            {
                _unitOfWork.StudentR.Remove(student);
                _unitOfWork.Save();
                TempData["success"] = "Student Deleted sucessfully";
            }
            return RedirectToAction("List", "Students");
        }
    }
}
