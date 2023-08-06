﻿using API.Domain.Entities;
using API.Domain.Interfaces.Services.User;
using API.Domain.Repository;
using System;
using System.Threading.Tasks;

namespace API.Service.Services
{
    public class LoginService : ILoginService
    {
        private readonly IUserRepository _repository;

        public LoginService(IUserRepository repository)
        {
            _repository = repository;
        }

        public async Task<object> FindByLogin(UserEntity user)
        {
            if (user != null && !string.IsNullOrEmpty(user.Email))
                return await _repository.FindByLogin(user.Email);
            else
                return null;
        }
    }
}
