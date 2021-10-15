using ELibrary.MVC.Model.DTO.RequestDTO;
using ELibrary.MVC.Model.DTO.ResponseDTO;
using ELibrary.MVC.Repository.Interfaces;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;
using System.Net.Http;

namespace ELibrary.MVC.Repository
{
    public class Rating : IRating
    {
        private readonly IServiceRepository _serviceRepository;

        public Rating(IConfiguration configuration, IServiceRepository serviceRepository)
        {
            _serviceRepository = serviceRepository;
        }

        /// <summary>
        /// Makes a GET Request, Fetches Ratings Records
        /// </summary>
        /// <returns></returns>
        public List<RatingResponseDTO> GetAllRatings()
        {
            HttpResponseMessage results = _serviceRepository.GetResponse("Rating/GetAll");
            results.EnsureSuccessStatusCode();
            List<RatingResponseDTO> ratings = results.Content.ReadAsAsync<List<RatingResponseDTO>>().Result;
            return ratings;
        }

        /// <summary>
        /// Makes a GET Request, Fetches Rating Record
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        public RatingResponseDTO GetRatingDetail(string Id)
        {
            HttpResponseMessage response = _serviceRepository.GetResponse("Rating/GetRating?id=" + Id);
            response.EnsureSuccessStatusCode();
            RatingResponseDTO rating = response.Content.ReadAsAsync<RatingResponseDTO>().Result;
            return rating;
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="rating"></param>
        /// <returns></returns>
        public RatingResponseDTO AddNewRating(RatingRequestDTO rating)
        {
            HttpResponseMessage response = _serviceRepository.PostResponse("Rating/AddNew", rating);
            response.EnsureSuccessStatusCode();
            RatingResponseDTO book = response.Content.ReadAsAsync<RatingResponseDTO>().Result;
            return book;
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="ratingRequest"></param>
        /// <returns></returns>
        public RatingResponseDTO UpdateRating(RatingRequestDTO ratingRequest)
        {
            HttpResponseMessage response = _serviceRepository.PutResponse("Rating/Update", ratingRequest);
            response.EnsureSuccessStatusCode();
            RatingResponseDTO rating = response.Content.ReadAsAsync<RatingResponseDTO>().Result;
            return rating;
        }

        /// <summary>
        /// Sends Delete Request, Removes Record
        /// <returns></returns>
        public HttpResponseMessage DeleteRating(string Id)
        {
            HttpResponseMessage response = _serviceRepository.DeleteResponse("Rating/Delete?" + Id);
            response.EnsureSuccessStatusCode();
            return response;
        }
    }
}