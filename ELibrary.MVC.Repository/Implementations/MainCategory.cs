using ELibrary.MVC.Model.DTO.RequestDTO;
using ELibrary.MVC.Model.DTO.ResponseDTO;
using ELibrary.MVC.Repository.Interfaces;
using System.Collections.Generic;
using System.Net.Http;

namespace ELibrary.MVC.Repository
{
    public class MainCategory : IMainCategory
    {
        private readonly IServiceRepository _serviceRepository;

        public MainCategory(IServiceRepository serviceRepository)
        {
            _serviceRepository = serviceRepository;
        }

        /// <summary>
        /// Makes a GET Request, Fetches MainCategory Records
        /// </summary>
        /// <returns></returns>
        public List<MainCategoryResponseDTO> GetAllCategory()
        {
            HttpResponseMessage results = _serviceRepository.GetResponse("Category/GetAll");
            results.EnsureSuccessStatusCode();
            List<MainCategoryResponseDTO> books = results.Content.ReadAsAsync<List<MainCategoryResponseDTO>>().Result;
            return books;
        }

        /// <summary>
        /// Makes a GET Request, Fetches Main Category Record
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        public MainCategoryResponseDTO GetCategoryDetail(string Id)
        {
            HttpResponseMessage response = _serviceRepository.GetResponse("Category/GetCategory?id=" + Id);
            response.EnsureSuccessStatusCode();
            MainCategoryResponseDTO category = response.Content.ReadAsAsync<MainCategoryResponseDTO>().Result;
            return category;
        }

        /// <summary>
        /// Makes a POST Request, Adds New Record
        /// </summary>
        /// <param name="bookRequestDTO"></param>
        /// <returns></returns>
        public MainCategoryResponseDTO AddNewCategory(MainCategoryRequestDTO mainCategoryRequestDTO)
        {
            HttpResponseMessage response = _serviceRepository.PostResponse("Category/AddNew", mainCategoryRequestDTO);
            response.EnsureSuccessStatusCode();
            MainCategoryResponseDTO book = response.Content.ReadAsAsync<MainCategoryResponseDTO>().Result;
            return book;
        }

        /// <summary>
        /// Makes PUT Request, Edits Category Record
        /// </summary>
        /// <param name="bookRequestDTO"></param>
        /// <returns></returns>
        public MainCategoryResponseDTO UpdateCategory(MainCategoryRequestDTO mainCategoryRequestDTO)
        {
            HttpResponseMessage response = _serviceRepository.PutResponse("Category/Update", mainCategoryRequestDTO);
            response.EnsureSuccessStatusCode();
            MainCategoryResponseDTO category = response.Content.ReadAsAsync<MainCategoryResponseDTO>().Result;
            return category;
        }

        public HttpResponseMessage DeleteCategory(string Id)
        {
            HttpResponseMessage response = _serviceRepository.DeleteResponse("Category/Delete?" + Id);
            response.EnsureSuccessStatusCode();
            return response;
        }
    }
}