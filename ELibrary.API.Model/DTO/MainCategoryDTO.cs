using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ELibrary.API.Model.DTO
{
    public class MainCategoryDTO
    {
        [Required]
        [StringLength(50)]
        public string Name { get; set; }

        public ICollection<SubCategoryDTO> SubCategories { get; set; }
    }
}