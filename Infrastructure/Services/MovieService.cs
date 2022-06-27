﻿using System;
using ApplicationCore.Contracts.Repositories;
using ApplicationCore.Contracts.Services;
using ApplicationCore.Models;

namespace Infrastructure.Services
{
	public class MovieService : IMovieService
	{
        private readonly IMovieRepository _movieRepository;

        public MovieService(IMovieRepository movieRepository)
        {
            _movieRepository = movieRepository;
        }

        public async Task<MovieDetailsModel> GetMovieDetails(int id)
        {
            var movieDetails = await _movieRepository.GetById(id);

            var movie = new MovieDetailsModel
            {
                Id = movieDetails.Id,
                Tagline = movieDetails.Tagline,
                Title = movieDetails.Title,
                Overview = movieDetails.Overview,
                PosterUrl = movieDetails.PosterUrl,
                BackdropUrl = movieDetails.BackdropUrl,
                ImdbUrl = movieDetails.ImdbUrl,
                RunTime = movieDetails.RunTime,
                TmdbUrl = movieDetails.TmdbUrl,
                Revenue = String.Format("{0:c}", movieDetails.Revenue),
                Budget = String.Format("{0:c}", movieDetails.Budget),
                ReleaseDate = movieDetails.ReleaseDate.Value.ToString("MMMM dd, yyyy"),
                ReleaseYear = movieDetails.ReleaseDate.Value.Year,
                Price = movieDetails.Price,
                Rating = Math.Round(await _movieRepository.GetAverageRatingForMovie(id), 2)
            };

            foreach (var genre in movieDetails.GenresOfMovies)
            {
                movie.Genres.Add(new GenreModel { Id = genre.GenreId, Name = genre.Genre.Name });
            }

            foreach (var trailer in movieDetails.Trailers)
            {
                movie.Trailers.Add(new TrailerModel { Id = trailer.Id, Name = trailer.Name, TrailerUrl = trailer.TrailerUrl });
            }


            foreach (var cast in movieDetails.CastOfMovies)
            {
                movie.Casts.Add(new CastModel { Id = cast.CastId, Name = cast.Cast.Name, Character = cast.Character, ProfilePath = cast.Cast.ProfilePath });
            }


            return movie;
        }

        public async Task<PagedResultSetModel<MovieCardModel>> GetMoviesByGenre(int genreId, int pageSize = 30, int pageNumber = 1)
        {
            var movies = await _movieRepository.GetMoviesByGenre(genreId, pageSize, pageNumber);

            var movieCards = new List<MovieCardModel>();

            foreach (var movie in movies.PagedData)
            {
                movieCards.Add(new MovieCardModel { Id = movie.Id, PosterUrl = movie.PosterUrl, Title = movie.Title });
            }

            return new PagedResultSetModel<MovieCardModel>(pageNumber, movies.TotalRecords, pageSize, movieCards);
        }

        public async Task<List<MovieCardModel>> GetTopGrossingMovies()
        {
            var movieCards = new List<MovieCardModel>();
            var movies = await _movieRepository.Get30HighestGrossingMovies();

            foreach (var movie in movies)
            {
                movieCards.Add(new MovieCardModel() { Id = movie.Id, PosterUrl = movie.PosterUrl, Title = movie.Title });
            }

            return movieCards;
        }
    }
}

