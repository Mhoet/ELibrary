using System.ComponentModel.DataAnnotations;

namespace ELibrary.API.Model.DTO
{
    public class RatingDTO
    {
        public string UserId { get; set; }
        public string BookId { get; set; }

        [Required]
        public double RatedValue { get; set; }

        public BookDTO Book { get; set; }
        public UserDTO User { get; set; }
    }
}