using System;
using System.ComponentModel.DataAnnotations;

namespace ELibrary.API.Model
{
    public class BaseModel
    {
        [Required]
        [StringLength(50)]
        public string Id { get; set; }

        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
}