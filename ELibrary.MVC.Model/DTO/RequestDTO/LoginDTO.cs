using System.ComponentModel.DataAnnotations;

namespace ELibrary.MVC.Model.DTO.RequestDTO
{
    public class LoginDTO
    {
        [Required(ErrorMessage = "Enter Email To Continue")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Enter Password To Continue")]
        public string Password { get; set; }
    }
}