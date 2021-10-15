using AutoMapper;
using ELibrary.API.Model;
using ELibrary.API.Model.DTO.RequestDTO;
using ELibrary.API.Services.ImageUploadService.Interface;
using ELibrary.API.Services.PaginationService.Implementation;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ELibrary.API.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly UserManager<User> _userManager;
        private readonly IUploadImage _uploadImage;
        private readonly IPageUriService _pageUriService;
        private readonly IMapper _mapper;

        public UserRepository(UserManager<User> userManager, IMapper mapper, IUploadImage uploadImage, IPageUriService pageUriService)
        {
            _userManager = userManager;
            _uploadImage = uploadImage;
            _pageUriService = pageUriService;
            _mapper = mapper;
        }

        /// <summary>
        /// Adds a new user to the data store
        /// </summary>
        /// <param name="filter"></param>
        /// <param name="route"></param>
        /// <returns></returns>
        public IEnumerable<User> GetAllUsers()
        {
            var result = _userManager.Users;
            return result;
        }

        /// <summary>
        /// Adds a new user to the data store
        /// </summary>
        /// <param name="userName"></param>
        /// <returns></returns>
        public async Task<User> GetUserByUserName(string userName) => await _userManager.FindByNameAsync(userName);

        /// <summary>
        /// Adds a new user to the data store
        /// </summary>
        /// <param name="userEmail"></param>
        /// <returns></returns>
        public async Task<User> GetUserByEmail(string userEmail) => await _userManager.FindByEmailAsync(userEmail);

        /// <summary>
        /// Adds a new user to the data store
        /// </summary>
        /// <param name="searchWord"></param>
        /// <returns></returns>
        public IEnumerable<User> SearchUsers(string searchWord)
        {
            searchWord = searchWord.Trim();
            var collection = _userManager.Users; // Fetches all users from the data store

            collection = collection.Where(user => user.UserName.Contains(searchWord) // Gets all Users whose fields contains the search word
            || user.FirstName.Contains(searchWord)
            || user.LastName.Contains(searchWord)
            || user.Email.Contains(searchWord));

            return collection.ToList(); // Returns the a piginated collection of selected users
        }

        /// <summary>
        /// Adds a new user to the data store
        /// </summary>
        /// <param name="registrationRequestDTO"></param>
        /// <returns></returns>
        public async Task<User> AddUser(RegistrationRequestDTO registrationRequestDTO)
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
                await _userManager.AddToRoleAsync(newUser, "Admin");
                return newUser;
            }
            string errors = String.Empty;
            foreach (var error in result.Errors)
            {
                errors += error.Description + Environment.NewLine;
            }
            throw new MissingFieldException(errors);
        }

        /// <summary>
        /// Removes a user from the data store
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        public async Task<bool> DeleteUser(string userId)
        {
            User user = await _userManager.FindByIdAsync(userId);
            if (user != null)
            {
                var result = await _userManager.DeleteAsync(user);
                if (result.Succeeded)
                    return true;
                return false;
            }
            throw new ArgumentException("User does not exist");
        }

        /// <summary>
        /// Updates the fields of an existing user in the data store. Returns a bool.
        /// </summary>
        /// <param name="updateUser"></param>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<bool> UpdateUser(UserUpdateRequestDTO updateUser, string id)
        {
            string imageUrl = string.Empty;
            if (updateUser.Image != null)              // Uploads the Image if there's any and assigns the Url to thumbnailUrl
            {
                var upload = _uploadImage.ImageUploadAsync(updateUser.Image);
                imageUrl = upload.Result.Url.ToString();
            }
            User user = await _userManager.FindByIdAsync(id);
            if (user == null)
            {
                throw new ArgumentException("User Not Found");
            }
            user.FirstName = String.IsNullOrWhiteSpace(updateUser.FirstName) ? user.FirstName : updateUser.FirstName;
            user.LastName = String.IsNullOrWhiteSpace(updateUser.LastName) ? user.LastName : updateUser.LastName;
            user.UserName = String.IsNullOrWhiteSpace(updateUser.UserName) ? user.UserName : updateUser.UserName;
            user.ImageUrl = String.IsNullOrWhiteSpace(imageUrl) ? user.ImageUrl : imageUrl;
            user.UpdatedAt = DateTime.Now;

            var result = await _userManager.UpdateAsync(user);
            if (result.Succeeded)
                return true;
            return false;
        }

        /// <summary>
        /// Updates the image url of an existing during a profile pic change. Returns a bool
        /// </summary>
        /// <param name="image"></param>
        /// <param name="Id"></param>
        /// <returns></returns>
        public async Task<bool> UpdateUserImageUrl(UpdateImageDTO updateImage)
        {
            User user = await _userManager.FindByIdAsync(updateImage.userId);
            if (user != null)
            {
                var upload = _uploadImage.ImageUploadAsync(updateImage.Image);
                string url = upload.Result.Url.ToString();

                user.ImageUrl = url;
                var result = await _userManager.UpdateAsync(user);
                if (result.Succeeded)
                    return true;
                return false;
            }
            else
                throw new ArgumentException("User Not Found");
        }
    }
}