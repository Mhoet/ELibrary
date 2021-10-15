using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ELibrary.API.Model
{
    public class SubCategory : BaseModel
    {
        [Required]
        [StringLength(50)]
        public string MainCategoryId { get; set; }

        [Required]
        [StringLength(50)]
        public string Name { get; set; }

        [Required]
        [StringLength(150), DataType(DataType.Text)]
        public string Description { get; set; }

        public MainCategory MainCategory { get; set; }
        public ICollection<Book> Books { get; set; }
    }
}