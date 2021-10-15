using ELibrary.API.Model;
using ELibrary.API.Model.DTO.RequestDTO;
using System.Collections.Generic;

namespace ELibrary.API.Repository
{
    public interface IReviewRepository
    {
        bool AddReview(AddReviewDTO addReview);

        bool UpdateReview(string reviewId, string comment);

        Review GetReviewById(string reviewId);

        IEnumerable<Review> GetReviewsByBookId(string bookId);
    }
}