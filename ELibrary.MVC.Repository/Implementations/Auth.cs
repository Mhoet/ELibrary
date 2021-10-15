using ELibrary.MVC.Model.DTO.RequestDTO;
using ELibrary.MVC.Model.DTO.ResponseDTO;
using ELibrary.MVC.Repository.Interfaces;
using System.Net.Http;

namespace ELibrary.MVC.Repository.Implementations
{
    public class Auth : IAuth
    {
        private readonly IServiceRepository _serviceRepository;

        public Auth(IServiceRepository serviceRepository)
        {
            _serviceRepository = serviceRepository;
        }

        public LoginResponseDTO Login(LoginDTO loginDTO)
        {
            HttpResponseMessage response = _serviceRepository.PostResponse("api/Auth/login", loginDTO);
            response.EnsureSuccessStatusCode();
            LoginResponseDTO login = response.Content.ReadAsAsync<LoginResponseDTO>().Result;
            return login;
        }

        public HttpResponseMessage Register(RegisterDTO registerDTO)
        {
            HttpResponseMessage response = _serviceRepository.PostResponse("api/Auth/register", registerDTO);
            response.EnsureSuccessStatusCode();
            HttpResponseMessage register = response.Content.ReadAsAsync<HttpResponseMessage>().Result;
            return register;
        }
    }
}