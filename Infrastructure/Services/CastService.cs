﻿using System;
using ApplicationCore.Contracts.Repositories;
using ApplicationCore.Contracts.Services;
using ApplicationCore.Entities.Extensions;
using ApplicationCore.Models;

namespace Infrastructure.Services
{
	public class CastService : ICastService
	{
        private readonly ICastRepository _castRepository;

        public CastService(ICastRepository castRepository)
        {
            _castRepository = castRepository;
        }

        public async Task<CastDetailsModel> GetCastDetails(int id)
        {
            var castDetails = await _castRepository.GetById(id);


            var cast = new CastDetailsModel()
            {
                Id = castDetails.Id,
                Name = castDetails.Name,
                Gender = castDetails.GetGender(),
                ProfilePath = castDetails.ProfilePath
            };

            foreach (var movie in castDetails.MoviesOfCast)
            {
                cast.Movies.Add(new MovieCardModel() { Id = movie.MovieId, PosterUrl = movie.Movie.PosterUrl, Title = movie.Movie.Title });
            }

            return cast;
        }
    }
}

