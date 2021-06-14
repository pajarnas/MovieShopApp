using System.Collections.Generic;
using System.Threading.Tasks;
using ApplicationCore.Entities;

namespace ApplicationCore.RepositoryInterfaces
{
    public interface IPurchaseRepository : IAsyncRepository<Purchase>
    {
        Task<IEnumerable<Purchase>> GetAllPurchases(int userId);
        Task<IEnumerable<Purchase>> GetAllPurchasesByMovie(int movieId, int pageSize = 30, int pageIndex = 0);

        int GetPurchasedMoviesCountByUser(int id);
    }
}