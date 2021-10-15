using ELibrary.MVC.Model.DTO.ResponseDTO;
using System.Collections.Generic;
using System.Net.Http;

namespace ELibrary.MVC.Repository.Interfaces
{
    public interface IUser
    {
        public List<UserResponseDTO> GetAllUsers();

        public UserResponseDTO GetUserDetail(string Id);

        public UserResponseDTO AddNewUser(UserRequestDTO userRequestDTO);

        public UserResponseDTO UpdateUser(UserRequestDTO userRequestDTO);

        public HttpResponseMessage DeleteUser(string Id);
    }
}