using System;
namespace ApplicationCore.Contracts.Services
{
	public interface IReviewService
	{
        Task<int> GetAverageMovieRating(int movieId);
    }
}

