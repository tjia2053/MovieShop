using System;
using ApplicationCore.Entities;

namespace ApplicationCore.Contracts.Repositories
{
	public interface IPurchaseRepository : IRepository<Purchase>
    {
        Task<IEnumerable<Purchase>> GetPurchasesByUserId(int id);
        Task<bool> CheckIfPurchaseExists(int userId, int movieId);
    }
}

