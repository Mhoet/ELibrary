using ELibrary.MVC.Model.DTO.RequestDTO;
using ELibrary.MVC.Model.DTO.ResponseDTO;
using System.Collections.Generic;
using System.Net.Http;

namespace ELibrary.MVC.Repository.Interfaces
{
    public interface IRating
    {
        public List<RatingResponseDTO> GetAllRatings();

        public RatingResponseDTO GetRatingDetail(string Id);

        public RatingResponseDTO AddNewRating(RatingRequestDTO rating);

        public RatingResponseDTO UpdateRating(RatingRequestDTO ratingRequest);

        public HttpResponseMessage DeleteRating(string Id);
    }
}