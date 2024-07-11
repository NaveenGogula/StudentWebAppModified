using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentWebApp.Models.Models
{
    public class DepartmentViewModel
    {

        [Required]
        public Department Department { get; set; }
        [Required]
       [ValidateNever] 
       public IEnumerable<SelectListItem> StudentList { get; set; }

        //public DepartmentViewModel(IEnumerable<SelectListItem> StudentList) { 
        //    this.StudentList = StudentList;
        //}
    }
}
