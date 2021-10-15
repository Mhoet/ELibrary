using ELibrary.API.Model;
using ELibrary.API.Model.DTO.RequestDTO;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ELibrary.API.Repository
{
    public interface IUserRepository
    {
        Task<User> AddUser(RegistrationRequestDTO registrationRequestDTO);

        Task<bool> DeleteUser(string userId);

        IEnumerable<User> GetAllUsers();

        Task<User> GetUserByEmail(string userEmail);

        Task<User> GetUserByUserName(string userName);

        IEnumerable<User> SearchUsers(string searchWord);

        Task<bool> UpdateUserImageUrl(UpdateImageDTO updateImage);

        Task<bool> UpdateUser(UserUpdateRequestDTO updateUser, string id);
    }
}