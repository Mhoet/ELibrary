using System.ComponentModel.DataAnnotations;

namespace ELibrary.API.Model.DTO
{
    public class ReviewDTO
    {
        public string UserId { get; set; }
        public string BookId { get; set; }

        [Required]
        [StringLength(150), DataType(DataType.Text)]
        public string Comment { get; set; }

        public BookDTO Book { get; set; }
        public UserDTO User { get; set; }
    }
}