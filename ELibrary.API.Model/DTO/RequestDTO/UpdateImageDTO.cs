using Microsoft.AspNetCore.Http;

namespace ELibrary.API.Model.DTO.RequestDTO
{
    public class UpdateImageDTO
    {
        public string userId { get; set; }
        public IFormFile Image { get; set; }
    }
}