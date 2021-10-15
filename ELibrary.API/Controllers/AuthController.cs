using ELibrary.API.Model.DTO.RequestDTO;
using ELibrary.API.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace ELibrary.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthUser _authUser;

        public AuthController(IAuthUser authUser)
        {
            _authUser = authUser;
        }

        //Handles users login requests
        [HttpPost]
        [Route("login", Name = "Login")]
        public async Task<IActionResult> Login(LoginRequestDTO loginRequest)
        {
            try
            {
                var loggedUser = await _authUser.Login(loginRequest);
                return Ok(loggedUser);
            }
            catch (AccessViolationException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        //Handles users registration request
        [HttpPost]
        [Route("register")]
        public async Task<IActionResult> Register(RegistrationRequestDTO regRequest)
        {
            try
            {
                var result = await _authUser.Register(regRequest);
                return CreatedAtRoute("Login", "");
            }
            catch (MissingFieldException errors)
            {
                return BadRequest(errors.Message);
            }
        }
    }
}