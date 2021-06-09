using System;
using System.Collections.Generic;
using System.Text;
using ApplicationCore.Entities;
using System.Threading.Tasks;
namespace ApplicationCore.RepositoryInterfaces
{
    public interface IGenreRepository : IAsyncRepository<Genre>
    {
        Task<IEnumerable<Genre>> GetGenresByMovie(int movieId);
    }
}
