using Microsoft.AspNetCore.Http;

namespace ELibrary.API.Model.DTO.RequestDTO
{
    public class UserUpdateRequestDTO
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string UserName { get; set; }
        public IFormFile Image { get; set; }
    }
}