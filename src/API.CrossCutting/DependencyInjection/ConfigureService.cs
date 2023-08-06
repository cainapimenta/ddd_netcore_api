using API.Domain.Interfaces.Services.User;
using API.Service.Services;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace API.CrossCutting.DependencyInjection
{
    public class ConfigureService
    {
        public static void ConfigureDependenciesService(IServiceCollection servicesCollection)
        {
            servicesCollection.AddTransient<IUserService, UserService>();
            servicesCollection.AddTransient<ILoginService, LoginService>();
        }
    }
}
