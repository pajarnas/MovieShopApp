using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using ApplicationCore.Entities;
using ApplicationCore.ServiceInterfaces;
using ApplicationCore.RepositoryInterfaces;
using System.Linq;
using AutoMapper;
using ApplicationCore.Models.Response;
using ApplicationCore.Entities;
namespace Infrastructure.Services
{
    public class GenreService : IGenreService
    {
        private readonly IEntityRepository<Genre> _genreRepository;
        private readonly IMapper _mapper;
        public GenreService(IEntityRepository<Genre> genreRepository,IMapper mapper)
        {
            _genreRepository = genreRepository;
            _mapper = mapper;
        }
        public async Task<IEnumerable<Genre>> GetAll()
        {
            return await _genreRepository.ListAllAsync();
        }

        public async Task<string> GetNameById(int id)
        {
            return  _genreRepository.GetByIdAsync(id).Result.Name;
        }
        
        public async Task<List<AssignedGenreModel>> GetAssignedGenreModelAsync()
        {
            var generesEntities = await _genreRepository.ListAllAsync();
            var assignedGenreModels = _mapper.Map<List<AssignedGenreModel>>(generesEntities);
            return assignedGenreModels;
        }

    }
}
