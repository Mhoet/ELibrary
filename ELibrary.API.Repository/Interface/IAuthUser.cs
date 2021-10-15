using ELibrary.API.Model;
using ELibrary.API.Model.DTO.RequestDTO;
using ELibrary.API.Model.DTO.ResponseDTO;
using System.Threading.Tasks;

namespace ELibrary.API.Repository
{
    public interface IAuthUser
    {
        Task<LoginResponseDTO> Login(LoginRequestDTO userRequest);

        Task<User> Register(RegistrationRequestDTO registrationRequestDTO);
    }
}