using ELibrary.MVC.Model.DTO.RequestDTO;
using ELibrary.MVC.Model.DTO.ResponseDTO;
using ELibrary.MVC.Repository.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;

namespace ELibrary.MVC.Controllers
{
    public class AdminController : Controller
    {
        private readonly IBook _adminBook;
        private readonly IUser _adminUser;
        private readonly IMainCategory _category;
        private readonly ISubCategory _subCategory;
        private readonly IRating _rating;
        private readonly IReview _review;

        public AdminController(
            IBook adminBook,
            IUser adminUser,
            IMainCategory category,
            ISubCategory subCategory,
            IRating rating,
            IReview review

            )
        {
            _adminUser = adminUser;
            _adminBook = adminBook;
            _category = category;
            _subCategory = subCategory;
            _rating = rating;
            _review = review;
        }

        public IActionResult Dashboard()
        {
            var users = _adminUser.GetAllUsers();
            ViewData["AllUsers"] = users;
            var books = _adminBook.GetAllBooks();
            ViewData["AllBooks"] = books;
            var usersCount = users.Count;
            var booksCount = books.Count;

            ViewData["usersCount"] = usersCount;
            ViewData["booksCount"] = booksCount;
            return View();
        }

        public IActionResult Rating()
        {
            return View();
        }

   

       
        public IActionResult Book()
        {
            try
            {
                var books = _adminBook.GetAllBooks();
                ViewData["FetchBooks"] = books;
                return View();
            }
            catch (Exception)
            {
                return View();
            }
        }

        public IActionResult AddBook()
        {
            return View();
        }

        public IActionResult AddBook(BookRequestDTO bookRequestDTO)
        {
            try
            {
                var result = _adminBook.AddNewBook(bookRequestDTO);
                return View();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public IActionResult Users()
        {
            try
            {
                var users = _adminUser.GetAllUsers();
                ViewData["AllUsers"] = users;
                return View();
            }
            catch (Exception)
            {

                return View();
            }
        }

        public IActionResult AddUser()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddUser(UserRequestDTO userRequestDTO)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return View();
                }
                var result = _adminUser.AddNewUser(userRequestDTO);
                return View();
            }
            catch (Exception)
            {
                TempData["error"] = "Oops something bad happened try again!";
                return View();
            }
        }

        public IActionResult Comment()
        {
            return View();
        }

        public IActionResult Category()
        {
            return View();
        }

        public IActionResult SubCategory()
        {
            return View();
        }
    }
}