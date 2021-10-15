using ELibrary.MVC.Model.DTO.RequestDTO;
using ELibrary.MVC.Model.DTO.ResponseDTO;
using System.Collections.Generic;
using System.Net.Http;

namespace ELibrary.MVC.Repository.Interfaces
{
    public interface IBook
    {
        public List<BookResponseDTO> GetAllBooks();

        public BookResponseDTO GetBookDetail(string Id);

        public BookResponseDTO AddNewBook(BookRequestDTO bookRequestDTO);

        public BookResponseDTO UpdateBook(BookRequestDTO bookRequestDTO);

        public HttpResponseMessage DeleteBook(string Id);

        public List<BookResponseDTO> SearchBook(string term);
    }
}