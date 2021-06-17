using System.Threading.Tasks;
using System.Collections.Generic;
using ApplicationCore.Models.Response;
using ApplicationCore.Entities;


namespace ApplicationCore.ServiceInterfaces
{
    public interface IGenreService
    {

        Task<IEnumerable<Genre>> GetAll();

        Task<string> GetNameById(int id);

         Task<List<AssignedGenreModel>> GetAssignedGenreModelAsync();

    }
}