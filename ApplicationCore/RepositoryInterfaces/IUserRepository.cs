﻿using System;
using System.Collections.Generic;
using System.Text;
using ApplicationCore.Entities;
using System.Threading.Tasks;
namespace ApplicationCore.RepositoryInterfaces
{
    public interface IUserRepository : IAsyncRepository<User>
    {
        Task<User> GetUserByEmail(string email);
    }
}
