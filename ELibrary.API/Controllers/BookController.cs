using ELibrary.API.Model.DTO.RequestDTO;
using ELibrary.API.Repository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace ELibrary.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookController : ControllerBase
    {
        private readonly IBookRepository _bookRepository;

        public BookController(IBookRepository bookRepository)
        {
            _bookRepository = bookRepository;
        }

        // Fetches all books in the data store
        [HttpGet("AllBooks")]
        public IActionResult GetAllBooks()
        {
            try
            {
                var result = _bookRepository.GetAllBooks();
                if (result == null)
                    return StatusCode(StatusCodes.Status500InternalServerError);
                return Ok(result);
            }
            catch (ArgumentException argEx)
            {
                return BadRequest(argEx.Message);
            }
        }

        // Fetches a book from the Data Store using it's Id
        [HttpGet("GetBook")]
        public IActionResult GetBook(string bookId)
        {
            try
            {
                var result = _bookRepository.GetBookById(bookId);
                if (result == null)
                    return StatusCode(StatusCodes.Status500InternalServerError);
                return Ok(result);
            }
            catch (ArgumentException argEx)
            {
                return BadRequest(argEx.Message);
            }
        }

        // Adds a new book to the datastore
        [HttpPost("NewBook")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> AddNewbook(AddBookRequestDTO newbook)
        {
            try
            {
                var result = await _bookRepository.AddBook(newbook);
                if (result == false)
                    return StatusCode(StatusCodes.Status500InternalServerError);
                return CreatedAtAction("SearchBook", newbook.Author);
            }
            catch (MissingFieldException errors)
            {
                return BadRequest(errors.Message);
            }
        }

        //Updates the properties of a specific book in the data store
        [HttpPatch("Update")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> UpdateBook(BookUpdateRequestDTO updatebook)
        {
            try
            {
                bool result = await _bookRepository.UpdateBook(updatebook);
                if (result == false)
                    return StatusCode(StatusCodes.Status500InternalServerError);
                return Ok("Book Updated Successfully");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // Fetches books whose properties contains the search word
        [HttpGet("Search")]
        public IActionResult SearchBook(string search)
        {
            try
            {
                var collection = _bookRepository.SearchBooks(search);
                if (collection == null)
                    return NotFound();
                return Ok(collection);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // Removes a book from the data store using the book Id
        [HttpDelete("Delete")]
        [Authorize(Roles = "Admin")]
        public IActionResult DeleteBookById(string id)
        {
            try
            {
                bool result = _bookRepository.DeleteBook(id);
                if (result == false)
                    return StatusCode(StatusCodes.Status500InternalServerError);
                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}