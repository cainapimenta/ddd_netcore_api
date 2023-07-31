﻿using API.Domain.Entities;
using API.Domain.Interfaces;
using API.Domain.Interfaces.Services.User;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace API.Service.Services
{
    public class UserService : IUserService
    {
        private readonly IRepository<UserEntity> _repository;

        public UserService(IRepository<UserEntity> repository)
        {
            _repository = repository;
        }

        public async Task<bool> Delete(Guid id)
            => await _repository.DeleteAsync(id);

        public async Task<UserEntity> Get(Guid id)
            => await _repository.SelectAsync(id);

        public async Task<IEnumerable<UserEntity>> GetAll()
            => await _repository.SelectAsync();

        public async Task<UserEntity> Post(UserEntity entity)
            => await _repository.InsertAsync(entity);

        public async Task<UserEntity> Put(UserEntity entity)
            => await _repository.UpdateAsync(entity);
    }
}
