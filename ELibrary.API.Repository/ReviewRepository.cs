using ELibrary.API.Data;
using ELibrary.API.Model;
using ELibrary.API.Model.DTO.RequestDTO;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ELibrary.API.Repository
{
    public class ReviewRepository : IReviewRepository
    {
        private readonly ElibraryDbContext _context;

        public ReviewRepository(ElibraryDbContext context)
        {
            _context = context;
        }

        // Fetches a review by using it's Id
        public Review GetReviewById(string reviewId)
        {
            return _context.Reviews.FirstOrDefault(review => review.Id == reviewId);
        }

        /// <summary>
        /// Adds a review to a specific book.
        /// </summary>
        /// <param name="addReview"></param>
        /// <returns></returns>
        public bool AddReview(AddReviewDTO addReview)
        {
            Review review = new()
            {
                Id = Guid.NewGuid().ToString(),
                UserId = addReview.UserId,
                BookId = addReview.BookId,
                Comment = addReview.Comment
            };
            // Saves the new review to the data store
            _context.Reviews.Add(review);
            var result = _context.SaveChangesAsync();
            if (result.IsCompleted)
                return true;
            return false;
        }

        /// <summary>
        /// Updates a specific review of a book
        /// </summary>
        /// <param name="reviewId"></param>
        /// <param name="comment"></param>
        /// <returns></returns>
        public bool UpdateReview(string reviewId, string comment)
        {
            //Gets the review to be updated by id and assign the new comment to the review comment field
            Review review = GetReviewById(reviewId);
            review.Comment = comment;

            // Saves the updated review comment to the data store
            _context.Reviews.Update(review);
            var result = _context.SaveChangesAsync();
            if (result.IsCompleted)
                return true;
            return false;
        }

        /// <summary>
        /// Gets all ratings for a particular book
        /// </summary>
        /// <param name="bookId"></param>
        /// <returns></returns>
        public IEnumerable<Review> GetReviewsByBookId(string bookId)
        {
            var collection = _context.Reviews;
            var selectedReviews = collection.Where(review => review.BookId == bookId);
            return selectedReviews;
        }
    }
}