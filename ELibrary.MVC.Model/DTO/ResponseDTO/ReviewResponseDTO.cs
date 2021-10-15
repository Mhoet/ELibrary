using System.ComponentModel.DataAnnotations;

namespace ELibrary.MVC.Model.DTO.ResponseDTO
{
    public class ReviewResponseDTO
    {
        public string Id { get; set; }
        public string UserId { get; set; }
        public string BookId { get; set; }

        [Required]
        [StringLength(150), DataType(DataType.Text)]
        public string Comment { get; set; }

        public BookResponseDTO Book { get; set; }
        public UserResponseDTO User { get; set; }
    }
}