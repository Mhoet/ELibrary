using CloudinaryDotNet.Actions;
using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;

namespace ELibrary.API.Services.ImageUploadService.Interface
{
    public interface IUploadImage
    {
        Task<UploadResult> ImageUploadAsync(IFormFile image);
    }
}