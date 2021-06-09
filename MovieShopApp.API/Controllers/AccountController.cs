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
    public class AccountController : ControllerBase
    {
        // GET: api/account
        [HttpGet]
        public IEnumerable<Account> Get()
        {
            return accounts;
        }

        // GET api/account/5
        [HttpGet("{id}")]
        public Account Get(int id)
        {
            return accounts.Where(c => c.Id == id).SingleOrDefault();
        }

        // POST api/account
        [HttpPost]
        public void Post([FromBody] Account account)
        {
            accounts.Add(account);
        }

        // GET api/account/login/
        [Route("login")]
        [HttpGet()]
        public string Login()
        {
            return "Success";
        }

        private static List<Account> accounts;
       
        static AccountController()
        {
            accounts = new List<Account>()
            {
                new Account { Id=1, Name="Smith1", Password="123456"},
                new Account { Id=2, Name="Smith2", Password="123456"},
                new Account { Id=3, Name="Smith3", Password="123456"},
                new Account { Id=4, Name="Smith4", Password="123456"},
                new Account { Id=5, Name="Smith5", Password="123456"},
                new Account { Id=6, Name="Smith6", Password="123456"},
                new Account { Id=7, Name="Smith7", Password="123456"}
            };
        }
    }
}
