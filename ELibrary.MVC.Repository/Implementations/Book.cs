using ELibrary.MVC.Model.DTO.RequestDTO;
using ELibrary.MVC.Model.DTO.ResponseDTO;
using ELibrary.MVC.Repository.Interfaces;
using System.Collections.Generic;
using System.Net.Http;

namespace ELibrary.MVC.Repository.Implementations
{
    public class Book : IBook
    {
        private readonly IServiceRepository _serviceRepository;

        public Book(IServiceRepository serviceRepository)
        {
            _serviceRepository = serviceRepository;
        }

        /// <summary>
        /// Makes a GET Request, Fetches Books Records
        /// </summary>
        /// <returns></returns>
        public List<BookResponseDTO> GetAllBooks()
        {
            HttpResponseMessage results =  _serviceRepository.GetResponse("api/Book/AllBooks");
            results.EnsureSuccessStatusCode();
            List<BookResponseDTO> books = results.Content.ReadAsAsync<List<BookResponseDTO>>().Result;
            return books;
        }

        /// <summary>
        /// Makes a GET Request, Fetches One Book Record
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        public BookResponseDTO GetBookDetail(string Id)
        {
            HttpResponseMessage response = _serviceRepository.GetResponse("api/Book/GetBook?bookId=" + Id);
            response.EnsureSuccessStatusCode();
            BookResponseDTO book = response.Content.ReadAsAsync<BookResponseDTO>().Result;
            return book;
        }

        /// <summary>
        /// Makes a POST Request, Adds New Record
        /// </summary>
        /// <param name="bookRequestDTO"></param>
        /// <returns></returns>
        public BookResponseDTO AddNewBook(BookRequestDTO bookRequestDTO)
        {
            HttpResponseMessage response = _serviceRepository.PostResponse("Book/AddNew", bookRequestDTO);
            response.EnsureSuccessStatusCode();
            BookResponseDTO book = response.Content.ReadAsAsync<BookResponseDTO>().Result;
            return book;
        }

        /// <summary>
        /// Makes PUT Request, Edits User Record
        /// </summary>
        /// <param name="bookRequestDTO"></param>
        /// <returns></returns>
        public BookResponseDTO UpdateBook(BookRequestDTO bookRequestDTO)
        {
            HttpResponseMessage response = _serviceRepository.PutResponse("Book/Update", bookRequestDTO);
            response.EnsureSuccessStatusCode();
            BookResponseDTO book = response.Content.ReadAsAsync<BookResponseDTO>().Result;
            return book;
        }

        public HttpResponseMessage DeleteBook(string Id)
        {
            HttpResponseMessage response = _serviceRepository.DeleteResponse("Book/Delete?" + Id);
            response.EnsureSuccessStatusCode();
            return response;
        }

        public List<BookResponseDTO> SearchBook(string term)
        {
            HttpResponseMessage response = _serviceRepository.GetResponse("Book/Delete?" + term);
            response.EnsureSuccessStatusCode();
            List<BookResponseDTO> book = response.Content.ReadAsAsync<List<BookResponseDTO>>().Result;
            return book;
        }
    }
}