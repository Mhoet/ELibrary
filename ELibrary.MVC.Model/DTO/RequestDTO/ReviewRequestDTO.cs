using ELibrary.MVC.Model.DTO.ResponseDTO;
using System.ComponentModel.DataAnnotations;

namespace ELibrary.MVC.Model.DTO.RequestDTO
{
    public class ReviewRequestDTO
    {
        public string UserId { get; set; }
        public string BookId { get; set; }

        [Required]
        [StringLength(150), DataType(DataType.Text)]
        public string Comment { get; set; }

        public BookRequestDTO Book { get; set; }
        public UserRequestDTO User { get; set; }
    }
}