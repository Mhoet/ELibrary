using System.ComponentModel.DataAnnotations;

namespace ELibrary.MVC.Model.DTO.ResponseDTO
{
    public class RatingResponseDTO
    {
        public string UserId { get; set; }
        public string BookId { get; set; }

        [Required]
        public double RatedValue { get; set; }

        public BookResponseDTO Book { get; set; }
        public UserResponseDTO User { get; set; }
    }
}