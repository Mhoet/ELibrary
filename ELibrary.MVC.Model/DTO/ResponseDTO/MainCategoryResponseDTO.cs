using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ELibrary.MVC.Model.DTO.ResponseDTO
{
    public class MainCategoryResponseDTO
    {
        [Required]
        [StringLength(50)]
        public string Name { get; set; }

        public ICollection<SubCategoryResponseDTO> SubCategories { get; set; }
    }
}