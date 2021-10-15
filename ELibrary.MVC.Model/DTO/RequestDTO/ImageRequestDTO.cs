using Microsoft.AspNetCore.Http;

namespace ELibrary.MVC.Model.DTO.RequestDTO
{
    public class ImageRequestDTO
    {
        public IFormFile Image { get; set; }
    }
}