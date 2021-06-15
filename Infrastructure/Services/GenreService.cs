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
namespace Infrastructure.Services
{
    public class GenreService : IGenreService
    {
        private readonly IGenreRepository _genreRepository;
        private readonly IMapper _mapper;
        public GenreService(IGenreRepository genreRepository,IMapper mapper)
        {
            _genreRepository = genreRepository;
            _mapper = mapper;
        }
        public async Task<IEnumerable<Genre>> GetAllGenreList()
        {
            return await _genreRepository.ListAllAsync();
        }

        public async Task<List<AssignedGenreModel>> GetAssignedGenreModelAsync()
        {
            var generesEntities = await GetAllGenreList();
            List<AssignedGenreModel> assignedGenreModels = new List<AssignedGenreModel>();
            foreach (var item in generesEntities)
            {
                assignedGenreModels.Add(_mapper.Map<AssignedGenreModel>(item));
            }
             
            return assignedGenreModels;
        }

    }
}
