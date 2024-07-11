using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Authorization.Infrastructure;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;
using Microsoft.IdentityModel.Tokens;
using StudentWebApp.DataAccess.Data;
using StudentWebApp.DataAccess.Repository.IRepository;
using StudentWebApp.Models;
using StudentWebApp.Models.Models;
using StudentWebApp.Models.Models.Entities;
using StudentWebApp.Utility;
using System.ComponentModel.DataAnnotations;
using System.Runtime.ExceptionServices;

namespace StudentWebApp.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = SD.Role_Admin)]
    public class DepartmentController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IWebHostEnvironment _webHostEnvironment;
        public DepartmentController(IUnitOfWork unitOfWork, IWebHostEnvironment webHostEnvironment)
        {
            _unitOfWork = unitOfWork;
            _webHostEnvironment = webHostEnvironment;
        }

        [HttpGet]
        public IActionResult Add()
        {
            IEnumerable<SelectListItem> StudentList = _unitOfWork.StudentR.GetAll().Select(x => new SelectListItem
            {
                Text = x.Name,
                Value = x.StudentId.ToString()
            });
            // ViewBag.StudentList = StudentList;
            DepartmentViewModel departmentViewModel = new()
            {
                StudentList = StudentList,
                Department = new Department()
            };
            return View(departmentViewModel);

        }

        [HttpPost]
        public IActionResult Add(DepartmentViewModel DepViewModel, IFormFile? file)
        {

            if (ModelState.IsValid)
            {
                string wwwRootPath = _webHostEnvironment.WebRootPath;
                if (file != null)
                {
                    string filename = Guid.NewGuid().ToString() + Path.GetExtension(file.FileName);
                    string productpath = Path.Combine(wwwRootPath, @"images\department");
                    using (var fileStream = new FileStream(Path.Combine(productpath, filename), FileMode.Create))
                    {
                        file.CopyTo(fileStream);
                    }
                    DepViewModel.Department.ImageUrl = @"\images\department\" + filename;
                }
            

            var DepartmentObj = new Department
            {
                DepartmentId = DepViewModel.Department.DepartmentId,
                DepartmentName = DepViewModel.Department.DepartmentName,
                Description = DepViewModel.Department.Description,
                HOD = DepViewModel.Department.HOD,
                DepartmentBlock = DepViewModel.Department.DepartmentBlock,
                StudentId = DepViewModel.Department.StudentId,
                //ImageUrl = DepViewModel.Department.ImageUrl
               // ImageUrl = string.IsNullOrEmpty(DepViewModel.Department.ImageUrl) ? null : DepViewModel.Department.ImageUrl
          
            };
                if (!string.IsNullOrEmpty(DepViewModel.Department.ImageUrl))
                {
                    DepartmentObj.ImageUrl = DepViewModel.Department.ImageUrl;
                }
                _unitOfWork.DepartmentR.Add(DepartmentObj);
            _unitOfWork.Save();
            TempData["success"] = "Student created sucessfully";
            return RedirectToAction("List", "Department");
        }    
            else
            {

                IEnumerable<SelectListItem> StudentList = _unitOfWork.StudentR.GetAll().Select(x => new SelectListItem
                {
                    Text = x.Name,
                    Value = x.StudentId.ToString()
                });
                DepartmentViewModel departmentViewModel = new()
                {
                    StudentList = StudentList,
                    //Department = new Department()
                };

                return View(departmentViewModel);
                //return RedirectToAction("Add", "Department");
            }
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
            var Departments1 = _unitOfWork.DepartmentR.GetAll(includeProperties : "Student");

            return View(Departments1);
        }

        [HttpGet]
        public IActionResult Edit(int? id)
        {
            IEnumerable<SelectListItem> StudentList = _unitOfWork.StudentR.GetAll().Select(x => new SelectListItem
            {
                Text = x.Name,
                Value = x.StudentId.ToString()
            });
            DepartmentViewModel departmentViewModel = new()
            {
                StudentList = StudentList,
            };

            var Departments1 = _unitOfWork.DepartmentR.Get(x => x.DepartmentId == id);
            departmentViewModel.Department = Departments1;
            return View(departmentViewModel);

        }
        [HttpPost]
        public IActionResult Edit(DepartmentViewModel DepViewModel, IFormFile? file)
        {
            var Department = _unitOfWork.DepartmentR.Get(x => x.DepartmentId == DepViewModel.Department.DepartmentId);
             //var ImgUrl = _unitOfWork.DepartmentR.Get(u => u.ImageUrl == DepViewModel.Department.ImageUrl);
            //var imgurl = Department.ImageUrl;
            string wwwRootPath = _webHostEnvironment.WebRootPath;
            //string filename = Guid.NewGuid().ToString() + Path.GetExtension(file.FileName);
            // string filename = Department.ImageUrl;
            //string productpath = Path.Combine(wwwRootPath, @"images\department");
            //var currentImagePath = Path.Combine(wwwRootPath, DepViewModel.Department.ImageUrl.TrimStart('\\'));
           if (file != null)
           {
            if (!string.IsNullOrEmpty(Department.ImageUrl))
            { 
               var oldimagepath = Path.Combine(wwwRootPath, Department.ImageUrl.TrimStart('\\'));
               if (System.IO.File.Exists(oldimagepath))
               {
                 System.IO.File.Delete(oldimagepath);
               }
               string filename = Guid.NewGuid().ToString() + Path.GetExtension(file?.FileName);
               string productpath = Path.Combine(wwwRootPath, @"images\department");
               using (var fileStream = new FileStream(Path.Combine(productpath, filename), FileMode.Create))
               {
                 file?.CopyTo(fileStream);
               }
               DepViewModel.Department.ImageUrl = @"\images\department\" + filename;
            }
           }

            if (Department is not null)
            {
                Department.DepartmentId = DepViewModel.Department.DepartmentId;
                Department.DepartmentName = DepViewModel.Department.DepartmentName;
                Department.Description = DepViewModel.Department.Description;
                Department.HOD = DepViewModel.Department.HOD;
                Department.DepartmentBlock = DepViewModel.Department.DepartmentBlock;
                Department.StudentId = DepViewModel.Department.StudentId;
                if (!string.IsNullOrEmpty(DepViewModel.Department.ImageUrl))
                {
                Department.ImageUrl = DepViewModel.Department.ImageUrl;
                }
                _unitOfWork.Save();
                TempData["success"] = "Department Edited Sucessfully";
            }
            return RedirectToAction("List", "Department");
        }

        // Above Edit Method can be wiitten in this way as well
        //public IActionResult Edit(Student AnyName)
        //{
        //    dbContext.Students.Update(AnyName);
        //    dbContext.SaveChanges();
        //    TempData["success"] = "Student Edited sucessfully";
        //    return RedirectToAction("List", "Students");
        //}

        [HttpPost]
        public IActionResult Delete(DepartmentViewModel DepModel)
        {
            var Department = _unitOfWork.DepartmentR.Get(x => x.DepartmentId == DepModel.Department.DepartmentId);
            if (Department is not null)
            {
                _unitOfWork.DepartmentR.Remove(Department);
                _unitOfWork.Save();
                TempData["success"] = "Department Deleted sucessfully";
            }
            return RedirectToAction("List", "Department");
        }
    }
}
