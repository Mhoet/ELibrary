using ELibrary.API.Model;
using ELibrary.API.Model.DTO.RequestDTO;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ELibrary.API.Repository
{
    public interface IBookRepository
    {
        Task<bool> AddBook(AddBookRequestDTO newbook);

        bool DeleteBook(string bookId);

        public IEnumerable<Book> GetAllBooks();

        Book GetBookById(string userId);

        IEnumerable<Book> SearchBooks(string searchBookRequest);

        Task<bool> UpdateBook(BookUpdateRequestDTO bookUpdate);
    }
}