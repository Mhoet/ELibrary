using ELibrary.MVC.Model.DTO.RequestDTO;
using Microsoft.AspNet.Identity.EntityFramework;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ELibrary.MVC.Model.DTO.ResponseDTO
{
    public class UserRequestDTO : IdentityUser
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

        public ICollection<RatingRequestDTO> Ratings { get; set; }
        public ICollection<ReviewRequestDTO> Reviews { get; set; }
    }
}