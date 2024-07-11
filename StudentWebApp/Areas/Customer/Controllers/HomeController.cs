using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using StudentWebApp.DataAccess.Repository;
using StudentWebApp.DataAccess.Repository.IRepository;
using StudentWebApp.Models;
using StudentWebApp.Models.Models;
using System.Collections.Generic;
using System.Diagnostics;

namespace StudentWebApp.Areas.Customer.Controllers
{
    [Area("Customer")]
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        // private readonly IWebHostEnvironment _webHostEnvironment;
        private readonly IUnitOfWork _unitOfWork;
        public HomeController(ILogger<HomeController> logger, IUnitOfWork unitOfWork/*, IWebHostEnvironment webHostEnvironment*/)
        {
            _logger = logger;
            // _webHostEnvironment = webHostEnvironment;
            _unitOfWork = unitOfWork;
        }

        public IActionResult Index(/*IFormFile? file*/)
        {
            //string wwwRootPath = _webHostEnvironment.WebRootPath;
            //if (file != null)
            //{
            //    string filename = Guid.NewGuid().ToString() + Path.GetExtension(file.FileName);
            //    string productpath = Path.Combine(wwwRootPath, @"images\department");
            //    using (var fileStream = new FileStream(Path.Combine(productpath, filename), FileMode.Create))
            //    {
            //        file.CopyTo(fileStream);
            //    }
            //    DepViewModel.Department.ImageUrl = @"\images\department\" + filename;
            //}

           // IEnumerable<Department> DepartmentList = (IEnumerable < Department >)_unitOfWork.StudentR.GetAll();

            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
