using ELibrary.API.Model;
using System.Threading.Tasks;

namespace ELibrary.API.Services
{
    public interface ITokenGenerator
    {
        Task<string> GenerateToken(User user);
    }
}