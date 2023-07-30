using API.Domain.Entities;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace API.Domain.Interfaces.Services.User
{
    public interface IUserService
    {
        Task<UserEntity> Get(Guid id);
        Task<IEnumerable<UserEntity>> GetAll();
        Task<UserEntity> Post(UserEntity entity);
        Task<UserEntity> Put(UserEntity entity);
        Task<bool> Delete(Guid id);
    }
}
