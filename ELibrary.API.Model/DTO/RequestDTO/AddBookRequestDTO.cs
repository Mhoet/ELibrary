using Microsoft.AspNetCore.Http;
using System;

namespace ELibrary.API.Model.DTO.RequestDTO
{
    public class AddBookRequestDTO
    {
        public string SubCategoryId { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
        public string Publisher { get; set; }
        public DateTime PublishedDate { get; set; }
        public string ISBN { get; set; }
        public IFormFile BookAvatar { get; set; }
        public string ShortDescription { get; set; }
        public string LongDescription { get; set; }
    }
}