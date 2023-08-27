using API.Data.Context;
using API.Data.Implementations;
using API.Domain.Entities;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
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
                    Email = Faker.Internet.Email(),
                    Name = Faker.Name.FullName()
                };

                var registroCriado = await repotitory.InsertAsync(entity);
                Assert.NotNull(registroCriado);
                Assert.Equal(entity.Email, registroCriado.Email);
                Assert.Equal(entity.Name, registroCriado.Name);
                Assert.False(registroCriado.Id == Guid.Empty);

                entity.Name = Faker.Name.First();
                var registroAtualizado = await repotitory.UpdateAsync(entity);

                Assert.NotNull(registroAtualizado);
                Assert.Equal(entity.Email, registroAtualizado.Email);
                Assert.Equal(entity.Name, registroAtualizado.Name);

                var registroExiste = await repotitory.ExistAsync(registroAtualizado.Id);
                Assert.True(registroExiste);

                var registroSelecionado = await repotitory.SelectAsync(registroAtualizado.Id);
                Assert.NotNull(registroSelecionado);
                Assert.Equal(registroAtualizado.Email, registroSelecionado.Email);
                Assert.Equal(registroAtualizado.Name, registroSelecionado.Name);

                var todosRegistros = await repotitory.SelectAsync();
                Assert.NotNull(todosRegistros);
                Assert.True(todosRegistros.Count() > 1);

                var removerRegistro = await repotitory.DeleteAsync(registroSelecionado.Id);
                Assert.True(removerRegistro);

                var usuarioByLogin = await repotitory.FindByLogin("adm@projeto.com.br");
                Assert.NotNull(usuarioByLogin);
                Assert.Equal("adm@projeto.com.br", usuarioByLogin.Email);
                Assert.Equal("Administrador", usuarioByLogin.Name);
            }
        }
    }
}
