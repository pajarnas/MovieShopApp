using System.Collections.Generic;
using System.Threading.Tasks;
using ApplicationCore.Entities;
using ApplicationCore.Models.Request;
using ApplicationCore.Models.Response;
namespace ApplicationCore.ServiceInterfaces
{
    public interface IPurchaseService
    {
        Task PurchaseMovie(Purchase purchase);
        Task<bool> IsMoviePurchased(PurchaseRequestModel purchaseRequest);
        Task<int> GetPurchasedMoviesCountByUser(int id);
        Task<IEnumerable<Purchase>> GetPurchasesByUser(int userId);

        Task<UserPurchasesResponseModel> GetUserPurchasesByUser(int id);
    }
}