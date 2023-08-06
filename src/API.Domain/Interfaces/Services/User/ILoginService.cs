using API.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace API.Domain.Interfaces.Services.User
{
    public interface ILoginService
    {
        Task<object> FindByLogin(UserEntity user);
    }
}
