using ELibrary.MVC.Model.DTO.ResponseDTO;
using ELibrary.MVC.Repository.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;

namespace ELibrary.MVC.Controllers
{
    public class BookController : Controller
    {
        private readonly IBook _book;

        public BookController(IBook book)
        {
            _book = book;
        }

        public IActionResult Index()
        {
            try
            {
                var result = _book.GetAllBooks();
                ViewData["AllBooks"] = result;
                return View();
            }
            catch (Exception)
            {
                return View();
            }
        }

        [HttpGet]
        [Route("Book/Details/{id}")]
        public ActionResult Details(string id)
        {
            BookResponseDTO result = _book.GetBookDetail(id);
            ViewData["ThumbNailUrl"] = result.ThumbnailUrl;
            ViewData["Author"] = result.Author;
            ViewData["LongDescription"] = result.LongDescription;
            ViewData["PublishedDate"] = result.PublishedDate.ToString("MMMM yyy");
            ViewData["Publisher"] = result.Publisher;
            ViewData["ISBN"] = result.ISBN;
            ViewData["Ratings"] = result.Ratings;
            ViewData["Reviews"] = result.Reviews;
            ViewData["BookTitle"] = result.Title;

            return View();
        }

        // GET: BookController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: BookController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: BookController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: BookController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: BookController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: BookController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}