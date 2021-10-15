using System.ComponentModel.DataAnnotations;

namespace ELibrary.API.Model
{
    public class Review : BaseModel
    {
        [Required]
        [StringLength(50)]
        public string UserId { get; set; }

        [Required]
        [StringLength(50)]
        public string BookId { get; set; }

        [Required]
        [StringLength(150), DataType(DataType.Text)]
        public string Comment { get; set; }

        public Book Book { get; set; }
        public User User { get; set; }
    }
}