using API.Data.Context;
using API.Data.Repository;
using API.Domain.Entities;
using API.Domain.Repository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace API.Data.Implementations
{
    public class UserImplementation : BaseRepository<UserEntity>, IUserRepository
    {
        private DbSet<UserEntity> _dbUsers;

        public UserImplementation(MyContext context) : base(context)
        {
            _dbUsers = context.Set<UserEntity>();
        }

        public async Task<UserEntity> FindByLogin(string email)
        {
            return await _dbUsers.FirstOrDefaultAsync(x => x.Email == email);
        }
    }
}
