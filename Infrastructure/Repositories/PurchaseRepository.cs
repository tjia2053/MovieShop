﻿using System;
using ApplicationCore.Contracts.Repositories;
using ApplicationCore.Entities;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories
{
	public class PurchaseRepository : Repository<Purchase>, IPurchaseRepository
    {
        public PurchaseRepository(MovieShopDbContext dbContext) : base(dbContext)
        {

        }

        public async Task<bool> CheckIfPurchaseExists(int userId, int movieId)
        {
            var purchase = await _dbContext.Purchases
                .Where(p => p.UserId == userId && p.MovieId == movieId)
                .FirstOrDefaultAsync();

            return purchase != null;
        }

        public async Task<IEnumerable<Purchase>> GetPurchasesByUserId(int id)
        {
            var purchases = await _dbContext.Purchases
                .Where(x => x.UserId == id)
                .Include(x => x.Movie)
                .OrderByDescending(x => x.Movie.Revenue)
                .ToListAsync();

            return purchases;
        }

    }
}

