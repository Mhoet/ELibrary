using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ELibrary.MVC.Model.DTO.ResponseDTO
{
    public class UserResponseDTO
    {
        [Required]
        [StringLength(50)]
        public string FirstName { get; set; }

        [Required]
        [StringLength(50)]
        public string LastName { get; set; }

        [Required]
        [StringLength(50)]
        public string ImageUrl { get; set; }

        [Required]
        public string Gender { get; set; }

        [Required]
        [StringLength(25)]
        public string Password { get; set; }
        public string Email { get; set; }
        public string UserName { get; set; }
        public string CreatedAt { get; set; }

        public ICollection<RatingResponseDTO> Ratings { get; set; }
        public ICollection<ReviewResponseDTO> Reviews { get; set; }
    }
}