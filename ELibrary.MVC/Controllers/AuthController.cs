using ELibrary.MVC.Model.DTO.RequestDTO;
using ELibrary.MVC.Repository.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;

namespace ELibrary.MVC.Controllers
{
    public class AuthController : Controller
    {
        private readonly IAuth _auth;

        public AuthController(IAuth auth)
        {
            _auth = auth;
        }

        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(LoginDTO loginDTO)
        {
            var handler = new JwtSecurityTokenHandler();

            if (ModelState.IsValid)
            {
                try
                {
                    var result = _auth.Login(loginDTO);
                    HttpContext.Session.SetString("user", JsonConvert.SerializeObject(result));
                    var decodedValue = handler.ReadJwtToken(result.Token);
                    var Claim = decodedValue.Claims.ElementAt(2);
                    if (Claim.Value == "Customer")
                    {
                        return RedirectToAction("Index", "Home");
                    }
                    return RedirectToAction("Dashboard", "Admin");
                }
                catch (Exception)
                {
                    TempData["error"] = "Oops something bad happened try again!";
                    return View();
                }
            }

            return View();
        }

        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Register(RegisterDTO registerDTO)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return View();
                }
                var result = _auth.Register(registerDTO);
                //  result.EnsureSuccessStatusCode();
                return RedirectToAction("Login");
            }
            catch (Exception)
            {
                TempData["error"] = "Oops something bad happened try again!";
                return View();
            }
        }

        public IActionResult LogOut()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Index", "Home");
        }
    }
}