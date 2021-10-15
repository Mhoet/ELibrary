using System.ComponentModel.DataAnnotations;

namespace ELibrary.API.Model.DTO.RequestDTO
{
    public class RegistrationRequestDTO
    {
        [Required]
        [StringLength(50)]
        public string FirstName { get; set; }

        [Required]
        [StringLength(50)]
        public string LastName { get; set; }

        [Required]
        [StringLength(50)]
        public string Email { get; set; }

        [Required]
        public string Gender { get; set; }

        public string UserName { get; set; }

        [Required]
        [StringLength(25)]
        public string Password { get; set; }
    }
}