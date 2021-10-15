using AutoMapper;
using ELibrary.API.Model;
using ELibrary.API.Model.DTO.RequestDTO;
using ELibrary.API.Model.DTO.ResponseDTO;
using ELibrary.API.Repository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ELibrary.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;

        public UserController(IUserRepository userRepository, IMapper mapper)
        {
            _userRepository = userRepository;
            _mapper = mapper;
        }

        /// <summary>
        /// Adds a user from the data store
        /// </summary>
        /// <param name="registrationRequestDTO"></param>
        /// <returns></returns>
        [HttpPost("add-new")]
        //  [Authorize(Roles = "Admin")]
        public async Task<IActionResult> AddUser(RegistrationRequestDTO registrationRequestDTO)
        {
            try
            {
                User result = await _userRepository.AddUser(registrationRequestDTO);
                return CreatedAtRoute("get-user-by-email", result.Email);
            }
            catch (MissingFieldException errors)
            {
                return BadRequest(errors.Message);
            }
        }

        /// <summary>
        /// Fetches a user from the data store using the user's email
        /// </summary>
        /// <param name="email"></param>
        /// <returns></returns>
        [HttpGet("get-user-by-email")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> GetUserByEmail(string email)
        {
            try
            {
                User result = await _userRepository.GetUserByEmail(email);
                if (result == null)
                    return NotFound("No user exists with this email");
                return Ok(result);
            }
            catch (ArgumentException errors)
            {
                return BadRequest(errors.Message);
            }
        }

        /// <summary>
        /// Fetches a user from the data store using the user's username
        /// </summary>
        /// <param name="userName"></param>
        /// <returns></returns>
        [HttpGet("get-user-by-username")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> GetUserByUsername(string userName)
        {
            try
            {
                User result = await _userRepository.GetUserByUserName(userName);
                if (result == null)
                    return NotFound("No user exists with this username");
                return Ok(result);
            }
            catch (ArgumentException errors)
            {
                return BadRequest(errors.Message);
            }
        }

        /// <summary>
        /// Update a user using the user's Id
        /// </summary>
        /// <param name="id"></param>
        /// <param name="search"></param>
        /// <returns></returns>
        [HttpGet("SearchUser")]
        public IActionResult SearchUser(string search)
        {
            try
            {
                var collection = _userRepository.SearchUsers(search);
                if (collection == null)
                    return NotFound();
                return Ok(_mapper.Map<IEnumerable<UserResponseDTO>>(collection));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        /// <summary>
        /// Update a user using the user's Id
        /// </summary>
        /// <param name="id"></param>
        /// <param name="userUpdate"></param>
        /// <returns></returns>
        [HttpPatch("update-user")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> UpdateUser(UserUpdateRequestDTO userUpdate, string id)
        {
            try
            {
                var result = await _userRepository.UpdateUser(userUpdate, id);
                if (result == false)
                    return StatusCode(StatusCodes.Status500InternalServerError);
                return Ok("Succesfully Updated");
            }
            catch (ArgumentException argEx)
            {
                return BadRequest(argEx.Message);
            }
        }

        /// <summary>
        /// Adds image to a user's profile
        /// </summary>
        /// <param name="id"></param>
        /// <param name="image"></param>
        /// <returns></returns>
        [HttpPatch("UpdateImage")]
        //[Route("Image")]
        // [Authorize(Roles = "Regular")]
        public async Task<IActionResult> UploadImage(UpdateImageDTO updateImage)
        {
            try
            {
                var result = await _userRepository.UpdateUserImageUrl(updateImage);
                return Ok("Image successfully updated");
            }
            catch (ArgumentException argEx)
            {
                return BadRequest(argEx.Message);
            }
        }

        /// <summary>
        /// Removes a user from the data store using the user's Id
        /// </summary>
        /// <param name=""></param>
        /// <returns></returns>
        [HttpGet("get-users")]
        // [Authorize(Roles = "Admin")]
        public IActionResult GetAllUsers()
        {
            try
            {
                var result = _userRepository.GetAllUsers();
                if (result == null)
                    return StatusCode(StatusCodes.Status500InternalServerError);
                return Ok(result);
            }
            catch (ArgumentException argEx)
            {
                return BadRequest(argEx.Message);
            }
        }

        /// <summary>
        /// Removes a user from the data store using the user's Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("delete")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> DeleteUserById(string id)
        {
            try
            {
                bool result = await _userRepository.DeleteUser(id);
                if (result == true)
                    return Ok("Delete Succesfull");
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}