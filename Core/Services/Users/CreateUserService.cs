﻿using System;
using System.Collections.Generic;
using BusinessEntities;
using Common;
using Core.Factories;
using Data.Repositories;

namespace Core.Services.Users
{
    [AutoRegister]
    public class CreateProductService : ICreateUserService
    {
        private readonly IUpdateUserService _updateUserService;
        private readonly IIdObjectFactory<User> _userFactory;
        private readonly IUserRepository _userRepository;

        public CreateProductService(IIdObjectFactory<User> userFactory, IUserRepository userRepository, IUpdateUserService updateUserService)
        {
            _userFactory = userFactory;
            _userRepository = userRepository;
            _updateUserService = updateUserService;
        }

        public User Create(Guid id, string name, string email, int age, UserTypes type, decimal? annualSalary, IEnumerable<string> tags)
        {
            var user = _userFactory.Create(id);
            _updateUserService.Update(user, name, email,age, type, annualSalary, tags);
            _userRepository.Save(user);
            return user;
        }
    }
}