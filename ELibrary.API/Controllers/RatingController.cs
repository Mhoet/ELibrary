using ELibrary.API.Model;
using ELibrary.API.Model.DTO.RequestDTO;
using ELibrary.API.Repository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;

namespace ELibrary.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RatingController : ControllerBase
    {
        private readonly IRatingRepository _ratingRepository;

        public RatingController(IRatingRepository ratingRepository)
        {
            _ratingRepository = ratingRepository;
        }

        [HttpPost("Add")]
        public IActionResult AddRating(AddRatingDTO addRating)
        {
            bool result = _ratingRepository.AddRating(addRating);
            if (!result)
                return StatusCode(StatusCodes.Status500InternalServerError);
            return Ok("Rated");
        }

        [HttpPatch("Update")]
        public IActionResult UpdateRating(string ratingId, int value)
        {
            bool result = _ratingRepository.UpdateRating(ratingId, value);
            if (!result)
                return StatusCode(StatusCodes.Status500InternalServerError);
            return Ok("Updated Successfully");
        }

        /// <summary>
        /// Fetches a Rating from the data store using the Rating Id
        /// </summary>
        /// <param name="ratingId"></param>
        /// <returns></returns>
        [HttpGet("get-Rating-by-Id")]
        //[Authorize(Roles = "User")]
        public IActionResult GetRatingById(string ratingId)
        {
            try
            {
                Rating result = _ratingRepository.GetRatingById(ratingId);
                return Ok(result);
            }
            catch (ArgumentException errors)
            {
                return BadRequest(errors.Message);
            }
        }

        /// <summary>
        /// Fetches a list of ratings from the data store that match the bookId
        /// </summary>
        /// <param name="bookId"></param>
        /// <returns></returns>
        [HttpGet("get-Rating-by-bookId")]
        [Authorize(Roles = "Admin")]
        public IActionResult GetRatingByBookId(string bookId)
        {
            try
            {
                var result = _ratingRepository.GetRatingsByBookId(bookId);
                return Ok(result);
            }
            catch (ArgumentException errors)
            {
                return BadRequest(errors.Message);
            }
        }
    }
}