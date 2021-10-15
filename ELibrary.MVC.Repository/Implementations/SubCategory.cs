using ELibrary.MVC.Model.DTO.RequestDTO;
using ELibrary.MVC.Model.DTO.ResponseDTO;
using ELibrary.MVC.Repository.Interfaces;
using System.Collections.Generic;
using System.Net.Http;

namespace ELibrary.MVC.Repository
{
    public class SubCategory : ISubCategory
    {
        private readonly IServiceRepository _serviceRepository;

        public SubCategory(IServiceRepository serviceRepository)
        {
            _serviceRepository = serviceRepository;
        }

        public SubCategoryResponseDTO AddNewCategory(SubCategoryRequestDTO subCategoryRequestDTO)
        {
            HttpResponseMessage response = _serviceRepository.PostResponse("SubCategory/AddNew", subCategoryRequestDTO);
            response.EnsureSuccessStatusCode();
            SubCategoryResponseDTO sub = response.Content.ReadAsAsync<SubCategoryResponseDTO>().Result;
            return sub;
        }

        public HttpResponseMessage DeleteSubCategory(string Id)
        {
            HttpResponseMessage response = _serviceRepository.DeleteResponse("SubCategory/Delete?=" + Id);
            response.EnsureSuccessStatusCode();
            return response;
        }

        public List<SubCategoryResponseDTO> GetAllSubCategory()
        {
            HttpResponseMessage results = _serviceRepository.GetResponse("SubCategory/GetAll");
            results.EnsureSuccessStatusCode();
            List<SubCategoryResponseDTO> sub = results.Content.ReadAsAsync<List<SubCategoryResponseDTO>>().Result;
            return sub;
        }

        public SubCategoryResponseDTO GetSubCategoryDetail(string Id)
        {
            HttpResponseMessage response = _serviceRepository.GetResponse("SubCategory/GetSubCategory?id=" + Id);
            response.EnsureSuccessStatusCode();
            SubCategoryResponseDTO sub = response.Content.ReadAsAsync<SubCategoryResponseDTO>().Result;
            return sub;
        }

        public SubCategoryResponseDTO UpdateSubCategory(SubCategoryRequestDTO ratingRequest)
        {
            HttpResponseMessage response = _serviceRepository.PutResponse("UpdateSubCategory/Update", ratingRequest);
            response.EnsureSuccessStatusCode();
            SubCategoryResponseDTO sub = response.Content.ReadAsAsync<SubCategoryResponseDTO>().Result;
            return sub;
        }
    }
}