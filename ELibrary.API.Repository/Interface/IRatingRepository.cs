using ELibrary.API.Model;
using ELibrary.API.Model.DTO.RequestDTO;
using System.Collections.Generic;

namespace ELibrary.API.Repository
{
    public interface IRatingRepository
    {
        Rating GetRatingById(string ratingId);

        bool AddRating(AddRatingDTO newRating);

        bool UpdateRating(string ratingId, int ratingValue);

        IEnumerable<Rating> GetRatingsByBookId(string bookId);
    }
}