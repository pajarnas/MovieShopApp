using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using ApplicationCore.Entities;
namespace ApplicationCore.ServiceInterfaces
{
    public interface IGenreService 
    {
        Task<IEnumerable<Genre>> GetAllGenreList();
        
        
    }
}
