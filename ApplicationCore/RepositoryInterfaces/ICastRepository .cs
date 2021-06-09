using System;
using System.Collections.Generic;
using System.Text;
using ApplicationCore.Entities;
using System.Threading.Tasks;
namespace ApplicationCore.RepositoryInterfaces
{
    public interface ICastRepository : IAsyncRepository<Cast>
    {
        Task<IEnumerable<Cast>> GetCastsByMovie(int movieId);
    }
}
