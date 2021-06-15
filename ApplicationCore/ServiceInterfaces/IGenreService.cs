using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using ApplicationCore.Entities;
using ApplicationCore.Models.Response;
namespace ApplicationCore.ServiceInterfaces
{
    public interface IGenreService 
    {
        Task<IEnumerable<Genre>> GetAllGenreList();

        Task<List<AssignedGenreModel>> GetAssignedGenreModelAsync();
    }
}
