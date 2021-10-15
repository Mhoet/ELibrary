using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ELibrary.API.Model
{
    public class MainCategory : BaseModel
    {
        [Required]
        [StringLength(50)]
        public string Name { get; set; }

        public ICollection<SubCategory> SubCategories { get; set; }
    }
}