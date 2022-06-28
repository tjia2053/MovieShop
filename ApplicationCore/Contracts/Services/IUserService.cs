using System;
using ApplicationCore.Entities;
using ApplicationCore.Models;

namespace ApplicationCore.Contracts.Services
{
	public interface IUserService
	{
        Task<bool> PurchaseMovie(PurchaseRequestModel purchaseRequest, int userId);
        Task<bool> IsMoviePurchased(PurchaseRequestModel purchaseRequest, int userId);
        Task<bool> IsMoviePurchased(int userId, int movieId);
        Task<IEnumerable<PurchaseRequestModel>> GetAllPurchasesForUserId(int id);
        Task<bool> AddFavorite(FavoriteRequestModel favoriteRequest);
        Task<bool> RemoveFavorite(FavoriteRequestModel favoriteRequest);
        Task<bool> FavoriteExists(int id, int movieId);
        Task<Favorite> GetFavoriteById(int userId, int movieId);
        Task<IEnumerable<MovieCardModel>> GetAllFavoritesForUser(int id);
        Task<bool> AddMovieReview(ReviewRequestModel reviewRequest);
        Task<ReviewRequestModel> GetReview(int userId, int movieId);
        Task<bool> UpdateMovieReview(ReviewRequestModel reviewRequest);
        Task<bool> DeleteMovieReview(int userId, int movieId);
    }
}

