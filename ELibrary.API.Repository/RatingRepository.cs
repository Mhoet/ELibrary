using ELibrary.API.Data;
using ELibrary.API.Model;
using ELibrary.API.Model.DTO.RequestDTO;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ELibrary.API.Repository
{
    public class RatingRepository : IRatingRepository
    {
        private readonly ElibraryDbContext _context;

        public RatingRepository(ElibraryDbContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Fetches a specific rating by using it's Id.
        /// </summary>
        /// <param name="ratingId"></param>
        /// <returns></returns>
        public Rating GetRatingById(string ratingId) => _context.Ratings.FirstOrDefault(rating => rating.Id == ratingId);

        /// <summary>
        /// Adds a specific rating to a book
        /// </summary>
        /// <param name="rating"></param>
        /// <returns></returns>
        public bool AddRating(AddRatingDTO newRating)
        {
            Rating rating = new()
            {
                Id = Guid.NewGuid().ToString(),
                UserId = newRating.UserId,
                BookId = newRating.BookId,
                RatedValue = newRating.RatedValue
            };
            _context.Ratings.Add(rating);
            var result = _context.SaveChangesAsync();
            if (result.IsCompleted)
                return true;
            return false;
        }

        /// <summary>
        /// Updates a specific rating of a book
        /// </summary>
        /// <param name="ratingId"></param>
        /// <returns></returns>
        public bool UpdateRating(string ratingId, int ratingValue)
        {
            //Gets the rating to be updated by id and assign the new rated value to the rating's rated value field
            Rating rating = GetRatingById(ratingId);
            rating.RatedValue = ratingValue;

            // Saves the updated rated value to the data store
            _context.Ratings.Update(rating);
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
        public IEnumerable<Rating> GetRatingsByBookId(string bookId)
        {
            var collection = _context.Ratings;
            var selectedRatings = collection.Where(rating => rating.BookId == bookId);
            return selectedRatings;
        }
    }
}