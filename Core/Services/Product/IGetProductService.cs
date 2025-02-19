using System;
using System.Collections.Generic;
using BusinessEntities;

namespace Core.Services.Product
{
    public interface IGetProductService
    {
        User GetUser(Guid id);

        IEnumerable<User> GetUsers(UserTypes? userType = null, string name = null, string email = null, string tag = null);
    }
}