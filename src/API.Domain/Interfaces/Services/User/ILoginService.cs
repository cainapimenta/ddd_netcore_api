using API.Domain.Dtos;
using System.Threading.Tasks;

namespace API.Domain.Interfaces.Services.User
{
    public interface ILoginService
    {
        Task<object> FindByLogin(LoginDto user);
    }
}
