using System;
using ApplicationCore.Entities;

namespace ApplicationCore.Contracts.Repositories
{
	public interface IFavoriteRepository
	{
        public interface IFavoriteRepository : IRepository<Favorite>
        {
            Task<Favorite> GetFavoriteById(int userId, int movieId);
            Task<IEnumerable<Favorite>> GetAllFavoriteMoviesByUserId(int userId);
        }
    }
}

