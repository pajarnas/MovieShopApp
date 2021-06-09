using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApplicationCore.Models.APIModels;
// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MovieShopApp.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CastController : ControllerBase
    {
        // GET: api/<CastController>
        [HttpGet("{id}")]
        public IEnumerable<Cast> Get(int id)
        {
            return genres.Where(c=>c.Id==id);
        }

        private static List<Cast> genres;
        static CastController()
        {
            genres = new List<Cast>()
            {
                new Cast { Id=1, Name="Smith1", Password="123456",Position=1},
                new Cast { Id=2, Name="Smith2", Password="123456",Position=2},
                new Cast { Id=3, Name="Smith3", Password="123456",Position=3},
                new Cast { Id=4, Name="Smith4", Password="123456",Position=4},
                new Cast { Id=5, Name="Smith5", Password="123456",Position=5},
                new Cast { Id=6, Name="Smith6", Password="123456",Position=6},
                new Cast { Id=7, Name="Smith7", Password="123456",Position=7}
            };
        }
    }
}
