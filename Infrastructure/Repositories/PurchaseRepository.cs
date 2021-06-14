using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApplicationCore.Entities;
using ApplicationCore.RepositoryInterfaces;
 
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories
{
    public class PurchaseRepository : EfRepository<Purchase>, IPurchaseRepository
    {
        public PurchaseRepository(MovieShopDbContext dbContext) : base(dbContext)
        {
        }

        public async Task<IEnumerable<Purchase>> GetAllPurchases(int userId)
        {
            var purchases = await _dbContext.Purchase.Include(m => m.Movie).Where(m=>m.UserId== userId)
                .ToListAsync();
            return purchases;
        }
   

        public async Task<IEnumerable<Purchase>> GetAllPurchasesByMovie(int movieId, int pageSize = 30,
            int pageIndex = 1)
        {
            var purchases = await _dbContext.Purchase.Where(p => p.MovieId == movieId).Include(m => m.Movie)
                //.Include(m => m.Customer)
                .OrderByDescending(p => p.PurchaseDateTime)
                .Skip((pageIndex - 1) * pageSize).Take(pageSize).ToListAsync();
            return purchases;
        }

        public int GetPurchasedMoviesCountByUser(int id)
        {
            var count =  _dbContext.Set<Purchase>().Include(m => m.Movie).Include(m => m.User).Where(m=>m.UserId==id).Count();
            return count;
        }
    }
}