using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ELibrary.MVC.Model.DTO.RequestDTO
{
    public class RegisterDTO
    {
        [Required(ErrorMessage = "First Name is required")]
        [StringLength(45, ErrorMessage = "Name entered is above the maximum letters allowed")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Last Name is required")]
        public string LastName { get; set; }

        [EmailAddress(ErrorMessage = "Email field is required")]
        [Required(ErrorMessage = "Email is not valid")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Password required")]
        public string Password { get; set; }

        [NotMapped]
        [Compare("Password", ErrorMessage = "Password doesn't match.")]
        [Required(ErrorMessage = "Password Must Match")]
        public string ConfirmPassword { get; set; }

        [Required(ErrorMessage = "Select Gender")]
        public string Gender { get; set; }
    }
}