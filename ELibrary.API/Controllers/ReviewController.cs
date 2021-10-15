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
    public class ReviewController : ControllerBase
    {
        private readonly IReviewRepository _reviewRepository;

        public ReviewController(IReviewRepository reviewRepository)
        {
            _reviewRepository = reviewRepository;
        }

        [HttpPost("Add")]
        public IActionResult AddReview(AddReviewDTO addReview)
        {
            bool result = _reviewRepository.AddReview(addReview);
            if (!result)
                return StatusCode(StatusCodes.Status500InternalServerError);
            return Ok("Comment Added");
        }

        [HttpPatch("Update")]
        public IActionResult UpdateReview(string reviewId, string Comment)
        {
            bool result = _reviewRepository.UpdateReview(reviewId, Comment);
            if (!result)
                return StatusCode(StatusCodes.Status500InternalServerError);
            return Ok("Updated Successfully");
        }

        /// <summary>
        /// Fetches a review from the data store using the review Id
        /// </summary>
        /// <param name="reviewId"></param>
        /// <returns></returns>
        [HttpGet("get-review-by-Id")]
        //[Authorize(Roles = "User")]
        public IActionResult GetReviewById(string reviewId)
        {
            try
            {
                Review result = _reviewRepository.GetReviewById(reviewId);
                return Ok(result);
            }
            catch (ArgumentException errors)
            {
                return BadRequest(errors.Message);
            }
        }

        /// <summary>
        /// Fetches a list of reviews from the data store that match the bookId
        /// </summary>
        /// <param name="bookId"></param>
        /// <returns></returns>
        [HttpGet("get-review-by-bookId")]
        [Authorize(Roles = "Admin")]
        public IActionResult GetReviewByBookId(string bookId)
        {
            try
            {
                var result = _reviewRepository.GetReviewsByBookId(bookId);
                return Ok(result);
            }
            catch (ArgumentException errors)
            {
                return BadRequest(errors.Message);
            }
        }
    }
}