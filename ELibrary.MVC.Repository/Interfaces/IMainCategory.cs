using ELibrary.MVC.Model.DTO.RequestDTO;
using ELibrary.MVC.Model.DTO.ResponseDTO;
using System.Collections.Generic;
using System.Net.Http;

namespace ELibrary.MVC.Repository.Interfaces
{
    public interface IMainCategory
    {
        public List<MainCategoryResponseDTO> GetAllCategory();

        public MainCategoryResponseDTO GetCategoryDetail(string Id);

        public MainCategoryResponseDTO AddNewCategory(MainCategoryRequestDTO bookRequestDTO);

        public MainCategoryResponseDTO UpdateCategory(MainCategoryRequestDTO bookRequestDTO);

        public HttpResponseMessage DeleteCategory(string Id);
    }
}