using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ELibrary.API.Model.DTO
{
    public class SubCategoryDTO
    {
        public string MainCategoryId { get; set; }

        [Required]
        [StringLength(50)]
        public string Name { get; set; }

        [Required]
        [StringLength(150), DataType(DataType.Text)]
        public string Description { get; set; }

        public MainCategoryDTO MainCategory { get; set; }
        public ICollection<BookDTO> Books { get; set; }
    }
}