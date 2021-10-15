using ELibrary.MVC.Model.DTO.RequestDTO;
using ELibrary.MVC.Model.DTO.ResponseDTO;
using System.Collections.Generic;
using System.Net.Http;

namespace ELibrary.MVC.Repository.Interfaces
{
    public interface ISubCategory
    {
        public List<SubCategoryResponseDTO> GetAllSubCategory();

        public SubCategoryResponseDTO GetSubCategoryDetail(string Id);

        public SubCategoryResponseDTO AddNewCategory(SubCategoryRequestDTO rating);

        public SubCategoryResponseDTO UpdateSubCategory(SubCategoryRequestDTO ratingRequest);

        public HttpResponseMessage DeleteSubCategory(string Id);
    }
}