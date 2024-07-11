using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using StudentWebApp.Models.Models.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentWebApp.Models.Models
{
    public class Department
    {
        [Key]
        public int DepartmentId { get; set; }
        [Required]
        public string? DepartmentName { get; set; }
        [Required]
        public string? Description { get; set; }
        [Required]
        public string? HOD { get; set; }
        [Required]
        [MaxLength(2)]
        public string? DepartmentBlock { get; set; }

        public int StudentId { get; set; }
        [ForeignKey("StudentId")]
        public Student? Student { get; set; }

        [ValidateNever]
        public string ImageUrl { get; set; }
    }
}
