using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentWebApp.Models.Models.Entities
{
    public class Student
    {
        [Key]
        public int StudentId { get; set; }
        public Guid Id { get; set; }

        public string Name { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }

        public bool Subscribed { get; set; }
    }


}
