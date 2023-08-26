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
using System;

namespace API.CrossCutting.DependencyInjection
{
    public class ConfigureRepository
    {
        public static void ConfigureDependenciesRepository(IServiceCollection servicesCollection)
        {
            servicesCollection.AddScoped(typeof(IRepository<>), typeof(BaseRepository<>));
            servicesCollection.AddScoped<IUserRepository, UserImplementation>();

            if (Environment.GetEnvironmentVariable("DATABASE").ToLower() == "SQLSERVER".ToLower())
                servicesCollection.AddDbContext<MyContext>(options => options.UseSqlServer(Environment.GetEnvironmentVariable("DB_CONNECTION")));
            else
                servicesCollection.AddDbContext<MyContext>(options => options.UseMySql(Environment.GetEnvironmentVariable("DB_CONNECTION")));

        }
    }
}
