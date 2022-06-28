using System;
using ApplicationCore.Models;

namespace ApplicationCore.Contracts.Services
{
	public interface IMovieService
	{
        Task<List<MovieCardModel>> GetTopGrossingMovies();
        Task<MovieDetailsModel> GetMovieDetails(int id, int userId = -1);
        Task<PagedResultSetModel<MovieCardModel>> GetMoviesByGenre(int genreId, int pageSize = 30, int pageNumber = 1, int paginationRange = 5);
    }
}

