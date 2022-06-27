﻿using System;
using ApplicationCore.Contracts.Repositories;
using ApplicationCore.Entities;
using ApplicationCore.Models;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories
{
    public class MovieRepository : Repository<Movie>, IMovieRepository
    {
        public MovieRepository(MovieShopDbContext dbContext) : base(dbContext)
        {
        }

        public async Task<IEnumerable<Movie>> Get30HighestGrossingMovies()
        {
            var movies = await _dbContext.Movies.OrderByDescending(x => x.Revenue).Take(30).ToListAsync();
            return movies;
        }

        public async Task<IEnumerable<Movie>> Get30HighestRatedMovies()
        {
            //get id's of movies with best averaged rating
            var avgRatingIds = await _dbContext.Reviews
                .GroupBy(g => g.MovieId, r => r.Rating)
                .Select(g => new
                {
                    MovieId = g.Key,
                    AvgRating = g.Average()
                })
                .OrderByDescending(x => x.AvgRating)
                .Take(30).ToListAsync();

            //get all movies from db with ids from avgRating list
            var movies = await _dbContext.Movies
                .Where(x => avgRatingIds
                .All(r => r.MovieId == x.Id)).ToListAsync();

            return movies;
        }

        public async Task<decimal> GetAverageRatingForMovie(int movieId)
        {
            var rating = await _dbContext.Reviews
                .Where(r => r.MovieId == movieId)
                .AverageAsync(x => x.Rating);

            return rating;
        }

        public async override Task<Movie> GetById(int id)
        {

            var movieDetails = await _dbContext.Movies
                .Include(m => m.GenresOfMovies).ThenInclude(m => m.Genre)
                .Include(m => m.Trailers)
                .Include(m => m.CastOfMovies).ThenInclude(m => m.Cast)
                .FirstOrDefaultAsync(m => m.Id == id);

            return movieDetails;
        }

        public async Task<PagedResultSetModel<Movie>> GetMoviesByGenre(int genreId, int pageSize = 30, int pageNumber = 1)
        {
            var totalMoviesForGenre = await _dbContext.MovieGenres.Where(m => m.GenreId == genreId).CountAsync();

            var movies = await _dbContext.MovieGenres
                .Where(m => m.GenreId == genreId)
                .Include(m => m.Movie)
                .OrderByDescending(m => m.Movie.Revenue)
                .Select(m => new Movie { Id = m.MovieId, PosterUrl = m.Movie.PosterUrl, Title = m.Movie.Title })
                .Skip((pageNumber - 1) * pageSize)
                .Take(pageSize).ToListAsync();

            var pagedMovies = new PagedResultSetModel<Movie>(pageNumber, totalMoviesForGenre, pageSize, movies);

            return pagedMovies;
        }
    }
}

