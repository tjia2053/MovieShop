using System;
using ApplicationCore.Entities;

namespace ApplicationCore.Contracts.Repositories
{
	public interface IReviewRepository : IRepository<Review>
	{
        Task<int> GetAverageMovieRating(int movieId);
        Task<Review> GetReview(int userId, int movieId);
    }
}

