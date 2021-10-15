using ELibrary.MVC.Model.DTO.ResponseDTO;
using System.ComponentModel.DataAnnotations;

namespace ELibrary.MVC.Model.DTO.RequestDTO
{
    public class RatingRequestDTO
    {
        public string UserId { get; set; }
        public string BookId { get; set; }

        [Required]
        public double RatedValue { get; set; }

        public BookRequestDTO Book { get; set; }
        public UserRequestDTO User { get; set; }
    }
}