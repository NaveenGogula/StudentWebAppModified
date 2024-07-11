using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace StudentWebApp.Models
{
    public class AddStudentViewModel
    {
        [DisplayName("User Name")]
        [Required]
        [MaxLength(30)]
        public string Name { get; set; }

        [Required]
        [RegularExpression(@"^[^@\s]+@[^@\s]+\.[^@\s]+$", ErrorMessage = "The email address is not in a valid format.")]
        public string Email { get; set; }

        [Required]
        [MaxLength(10)]
        [RegularExpression("^[0-9]{10}$", ErrorMessage = "Phone number must be exactly 10 digits.")]
        public string Phone { get; set; }
        public bool Subscribed { get; set; }

    }
}
