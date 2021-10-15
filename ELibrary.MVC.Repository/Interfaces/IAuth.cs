using ELibrary.MVC.Model.DTO.RequestDTO;
using ELibrary.MVC.Model.DTO.ResponseDTO;
using System.Net.Http;

namespace ELibrary.MVC.Repository.Interfaces
{
    public interface IAuth
    {
        public HttpResponseMessage Register(RegisterDTO registerDTO);

        public LoginResponseDTO Login(LoginDTO loginDTO);
    }
}