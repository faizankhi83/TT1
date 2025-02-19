﻿using System;
using System.Collections.Generic;
using BusinessEntities;
using Common;
using Data.Repositories;

namespace Core.Services.Product
{
    [AutoRegister]
    public class GetProductService : IGetProductService
    {
        private readonly IUserRepository _userRepository;

        public GetProductService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public User GetUser(Guid id)
        {
            return _userRepository.Get(id);
        }

        public IEnumerable<User> GetUsers(UserTypes? userType = null, string name = null, string email = null, string tag = null)
        {
            return _userRepository.Get(userType, name, email, tag);
        }
    }
}