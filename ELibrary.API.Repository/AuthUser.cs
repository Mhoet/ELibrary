using AutoMapper;
using ELibrary.API.Model;
using ELibrary.API.Model.DTO.RequestDTO;
using ELibrary.API.Model.DTO.ResponseDTO;
using ELibrary.API.Services;
using ELibrary.API.Services.ImageUploadService.Interface;
using Microsoft.AspNetCore.Identity;
using System;
using System.Threading.Tasks;

namespace ELibrary.API.Repository
{
    public class AuthUser : IAuthUser
    {
        private readonly UserManager<User> _userManager;
        private readonly IUploadImage _uploadImage;
        private readonly ITokenGenerator _tokenGenerator;
        private readonly IMapper _mapper;

        public AuthUser(UserManager<User> userManager, IUploadImage uploadImage, ITokenGenerator tokenGenerator, IMapper mapper)
        {
            _userManager = userManager;
            _uploadImage = uploadImage;
            _tokenGenerator = tokenGenerator;
            _mapper = mapper;
        }

        // Logs in an existing User
        public async Task<LoginResponseDTO> Login(LoginRequestDTO userRequest)
        {
            User user = await _userManager.FindByEmailAsync(userRequest.Email);
            if (user != null)
            {
                if (await _userManager.CheckPasswordAsync(user, userRequest.Password) == true)
                {
                    var loggedUser = _mapper.Map<LoginResponseDTO>(user);
                    loggedUser.Token = await _tokenGenerator.GenerateToken(user);
                    return loggedUser;
                }
                throw new AccessViolationException("Wrong UserName or Password");
            }
            throw new AccessViolationException("Wrong UserName or Password");
        }

        // Registers a new User
        public async Task<User> Register(RegistrationRequestDTO registrationRequestDTO)
        {
            registrationRequestDTO.UserName = String.IsNullOrWhiteSpace(registrationRequestDTO.UserName) ? registrationRequestDTO.Email : registrationRequestDTO.UserName;

            User newUser = new()
            {
                Id = Guid.NewGuid().ToString(),
                FirstName = registrationRequestDTO.FirstName,
                LastName = registrationRequestDTO.LastName,
                Email = registrationRequestDTO.Email,
                Gender = registrationRequestDTO.Gender,
                UserName = registrationRequestDTO.UserName,
                CreatedAt = DateTime.Now,
            };
            IdentityResult result = await _userManager.CreateAsync(newUser, registrationRequestDTO.Password);
            if (result.Succeeded)
            {
                await _userManager.AddToRoleAsync(newUser, "Customer");
                return newUser;
            }
            string errors = String.Empty;
            foreach (var error in result.Errors)
            {
                errors += error.Description + Environment.NewLine;
            }
            throw new MissingFieldException(errors);
        }
    }
}