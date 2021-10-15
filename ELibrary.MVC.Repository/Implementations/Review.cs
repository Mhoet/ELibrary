using ELibrary.MVC.Model.DTO.RequestDTO;
using ELibrary.MVC.Model.DTO.ResponseDTO;
using ELibrary.MVC.Repository.Interfaces;
using System.Collections.Generic;
using System.Net.Http;

namespace ELibrary.MVC.Repository
{
    public class Review : IReview
    {
        private readonly IServiceRepository _serviceRepository;

        public Review(IServiceRepository serviceRepository)
        {
            _serviceRepository = serviceRepository;
        }

        public ReviewResponseDTO AddNewRating(ReviewRequestDTO rating)
        {
            HttpResponseMessage response = _serviceRepository.PostResponse("Rating/AddNew", rating);
            response.EnsureSuccessStatusCode();
            ReviewResponseDTO review = response.Content.ReadAsAsync<ReviewResponseDTO>().Result;
            return review;
        }

        public HttpResponseMessage DeleteReview(string Id)
        {
            HttpResponseMessage response = _serviceRepository.DeleteResponse("Rewview/Delete?" + Id);
            response.EnsureSuccessStatusCode();
            return response;
        }

        public List<ReviewResponseDTO> GetAllReviews()
        {
            HttpResponseMessage results = _serviceRepository.GetResponse("Review/GetAll");
            results.EnsureSuccessStatusCode();
            List<ReviewResponseDTO> review = results.Content.ReadAsAsync<List<ReviewResponseDTO>>().Result;
            return review;
        }

        public ReviewResponseDTO GetReviewDetail(string Id)
        {
            HttpResponseMessage response = _serviceRepository.GetResponse("Review/GetRating?id=" + Id);
            response.EnsureSuccessStatusCode();
            ReviewResponseDTO review = response.Content.ReadAsAsync<ReviewResponseDTO>().Result;
            return review;
        }

        public ReviewResponseDTO UpdateReview(ReviewRequestDTO ratingRequest)
        {
            HttpResponseMessage response = _serviceRepository.PutResponse("Review/Update", ratingRequest);
            response.EnsureSuccessStatusCode();
            ReviewResponseDTO review = response.Content.ReadAsAsync<ReviewResponseDTO>().Result;
            return review;
        }
    }
}