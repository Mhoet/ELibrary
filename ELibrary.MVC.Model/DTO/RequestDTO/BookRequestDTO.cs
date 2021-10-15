using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ELibrary.MVC.Model.DTO.RequestDTO
{
    public class BookRequestDTO : BaseModel
    {
        public string SubCategoryId { get; set; }

        [Required]
        [StringLength(50)]
        public string Title { get; set; }

        [Required]
        [StringLength(50)]
        public string Author { get; set; }

        [Required]
        [StringLength(50)]
        public string Publisher { get; set; }

        [Required]
        public DateTime PublishedDate { get; set; }

        [Required]
        [StringLength(10)]
        public string ISBN { get; set; }

        [Required]
        [StringLength(150)]
        public string ThumbnailUrl { get; set; }

        [Required]
        [StringLength(150), DataType(DataType.Text)]
        public string ShortDescription { get; set; }

        [Required]
        [StringLength(500), DataType(DataType.Text)]
        public string LongDescription { get; set; }

        public SubCategoryRequestDTO SubCategory { get; set; }
        public ICollection<RatingRequestDTO> Ratings { get; set; }
        public ICollection<ReviewRequestDTO> Reviews { get; set; }
    }
}