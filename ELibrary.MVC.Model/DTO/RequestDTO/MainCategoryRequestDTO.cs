using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ELibrary.MVC.Model.DTO.RequestDTO
{
    public class MainCategoryRequestDTO
    {
        [Required]
        [StringLength(50)]
        public string Name { get; set; }

        public ICollection<SubCategoryRequestDTO> SubCategories { get; set; }
    }
}