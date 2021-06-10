using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ApplicationCore.Entities;
using ApplicationCore.Models.Request;

namespace ApplicationCore.ServiceInterfaces
{
    public interface IAdminService
    {
        Task<Movie> AddMovieWithGenres(CreateMovieRequestModel model);

        
    }
}
