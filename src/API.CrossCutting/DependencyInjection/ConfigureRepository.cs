using API.Data.Context;
using API.Data.Implementations;
using API.Data.Repository;
using API.Domain.Interfaces;
using API.Domain.Interfaces.Services.User;
using API.Domain.Repository;
using API.Domain.Security;
using API.Service.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace API.CrossCutting.DependencyInjection
{
    public class ConfigureRepository
    {
        public static void ConfigureDependenciesRepository(IServiceCollection servicesCollection)
        {
            servicesCollection.AddScoped(typeof(IRepository<>), typeof(BaseRepository<>));
            servicesCollection.AddScoped<IUserRepository, UserImplementation>();
            servicesCollection.AddDbContext<MyContext>(
                options => options.UseMySql("Server=localhost;Port=3306;Database=dbAPI;Uid=root;Pwd=B1admin@")
            );

            
            servicesCollection.AddSingleton<SigningConfigurations>();
        }
    }
}
