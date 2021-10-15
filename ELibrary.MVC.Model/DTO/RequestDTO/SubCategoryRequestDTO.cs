using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ELibrary.MVC.Model.DTO.RequestDTO
{
    public class SubCategoryRequestDTO
    {
        public string MainCategoryId { get; set; }

        [Required]
        [StringLength(50)]
        public string Name { get; set; }

        [Required]
        [StringLength(150), DataType(DataType.Text)]
        public string Description { get; set; }

        public MainCategoryRequestDTO MainCategory { get; set; }
        public ICollection<BookRequestDTO> Books { get; set; }
    }
}