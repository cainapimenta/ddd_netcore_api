using API.Data.Context;
using API.Data.Implementations;
using API.Domain.Entities;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Api.Data.Test
{
    public class UserCrudComplet : BaseTest, IClassFixture<DbTeste>
    {
        private readonly ServiceProvider _serviceProvider;

        public UserCrudComplet(DbTeste dbTeste)
        {
            _serviceProvider = dbTeste.ServiceProvider;
        }

        [Fact(DisplayName = "CRUD de Usuário")]
        [Trait("CRUD", "UserEntity")]
        public async Task E_Possivel_Realizar_CRUD_Usuario()
        {
            using(var context = _serviceProvider.GetService<MyContext>())
            {
                var repotitory = new UserImplementation(context);
                var entity = new UserEntity()
                {
                    Email = "teste@email.com",
                    Name = "Tatatatatututut"
                };

                var registroCriado = await repotitory.InsertAsync(entity);
                Assert.NotNull(registroCriado);

                Assert.Equal("teste@email.com", registroCriado.Email);
                Assert.Equal("Tatatatatututut", registroCriado.Name);
                Assert.False(registroCriado.Id == Guid.Empty);
            }
        }
    }
}
