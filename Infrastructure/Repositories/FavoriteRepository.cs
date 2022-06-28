﻿using System;
using ApplicationCore.Contracts.Repositories;
using ApplicationCore.Entities;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories
{
	public class FavoriteRepository : Repository<Favorite>, IFavoriteRepository
    {
        public FavoriteRepository(MovieShopDbContext dbContext) : base(dbContext)
        {
        }

        public async Task<Favorite> GetFavoriteById(int userId, int movieId)
        {
            var favorite = await _dbContext.Favorites.FirstOrDefaultAsync(x => x.UserId == userId && x.MovieId == movieId);
            return favorite;
        }

        public override async Task<Favorite> Delete(Favorite entity)
        {
            var local = _dbContext.Set<Favorite>()
                .Local
                .FirstOrDefault(x => x.Id == entity.Id);

            if (local != null)
            {
                _dbContext.Entry(local).State = EntityState.Detached;
            }

            _dbContext.Set<Favorite>().Remove(entity);

            await _dbContext.SaveChangesAsync();

            return entity;
        }

        public async Task<IEnumerable<Favorite>> GetAllFavoriteMoviesByUserId(int userId)
        {
            var movies = await _dbContext.Favorites
                .Where(x => x.UserId == userId)
                .Include(x => x.Movie)
                .OrderByDescending(x => x.Movie.Revenue)
                .ToListAsync();

            return movies;
        }
    }
}

