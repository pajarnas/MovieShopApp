using System;
using ApplicationCore.Entities;
using ApplicationCore.RepositoryInterfaces;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using ApplicationCore.Models.Response;
using System.Threading.Tasks;
using System.Collections.Generic;
using ApplicationCore.Models.Request;
using ApplicationCore.ServiceInterfaces;
using AutoMapper;

namespace Infrastructure.Repositories
{
    public class PurchaseService:IPurchaseService
    {
        private readonly IRelationRepository<Purchase> _relationRepository;
        private readonly IEntityRepository<Purchase> _purchaseRepository;
        private readonly IMapper _mapper;
        public PurchaseService(IRelationRepository<Purchase> repository, IEntityRepository<Purchase> purchaseRepository,IMapper mapper)
        {
            _relationRepository = repository;
            _purchaseRepository = purchaseRepository;
            _mapper = mapper;
        }

        public async Task PurchaseMovie(Purchase purchase)
        {
            
            await _purchaseRepository.AddAsync(purchase);
        }
        public async Task<IEnumerable<Purchase>> GetPurchasesByUser(int userId)
        {
            var purchaseList =
                await _relationRepository.ListWithIncludesAsync(p => p.Include(m => m.Movie).Include(m=>m.User), m => m.UserId == userId);
   
            return purchaseList;
        }
        
        public async Task<bool> IsMoviePurchased(PurchaseRequestModel purchaseRequest)
        {
            return await _purchaseRepository.GetExistsAsync(p =>
                p.UserId == purchaseRequest.UserId && p.MovieId == purchaseRequest.MovieId);
        }

        public async Task<IEnumerable<Purchase>> GetAllPurchasesByMovie(int movieId, int pageSize = 30,
            int pageIndex = 1)
        {
            var purchases = await _relationRepository.ListWithIncludesAsync(p => p.Include(m => m.Movie).Include(m => m.User),
               p => p.UserId == movieId);
            
            return purchases;
        }
        
        public async Task<int> GetPurchasedMoviesCountByUser(int id)
        {
            var purchases = await GetPurchasesByUser(id);
            var count =  purchases.Count();
            return count;
        }

        public async Task<UserPurchasesResponseModel> GetUserPurchasesByUser(int id)
        {
            var purchases = await GetPurchasesByUser(id);
            var purchaseModel = _mapper.Map<UserPurchasesResponseModel>(purchases);
            return purchaseModel;
        }
    }
}