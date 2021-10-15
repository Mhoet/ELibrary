using System.ComponentModel.DataAnnotations;

namespace ELibrary.API.Model
{
    public class Rating : BaseModel
    {
        [Required]
        [StringLength(50)]
        public string UserId { get; set; }

        [Required]
        [StringLength(50)]
        public string BookId { get; set; }

        public double RatedValue { get; set; }
        public Book Book { get; set; }
        public User User { get; set; }
    }
}