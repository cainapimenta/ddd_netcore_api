using API.Domain.Dtos;
using API.Domain.Interfaces.Services.User;
using API.Domain.Repository;
using API.Domain.Security;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Principal;
using System.Threading.Tasks;

namespace API.Service.Services
{
    public class LoginService : ILoginService
    {
        private readonly IUserRepository _repository;
        private readonly SigningConfigurations _signingConfigurations;
        private readonly TokenConfigurations _tokenConfigurations;
        private readonly IConfiguration _configuration;

        public LoginService(IUserRepository repository, SigningConfigurations signingConfigurations, TokenConfigurations tokenConfigurations, IConfiguration configuration)
        {
            _repository = repository;
            _signingConfigurations = signingConfigurations;
            _tokenConfigurations = tokenConfigurations;
            _configuration = configuration;
        }

        public async Task<object> FindByLogin(LoginDto user)
        {
            var baseUser = await _repository.FindByLogin(user.Email);

            if (baseUser != null)
            {
                var identity = new ClaimsIdentity(
                    new GenericIdentity(baseUser.Email),
                    new[]
                    {
                        new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()), //JTI o Id do Token
                        new Claim(JwtRegisteredClaimNames.UniqueName, user.Email)
                    }
                );

                var createDate = DateTime.Now;
                var expirationDate = createDate.AddSeconds(_tokenConfigurations.Seconds);

                var token = CreateToken(identity, createDate, expirationDate);
                return SuccesObject(user, token, createDate, expirationDate);
            }
            else
            { 
                return new
                {
                    authenticaded = false,
                    message = "Fala ao autenticar."
                };
            }
        }

        private string CreateToken(ClaimsIdentity identity, DateTime createDate, DateTime expirationDate)
        {   
            var handler = new JwtSecurityTokenHandler();

            var securityToken = handler.CreateToken(new SecurityTokenDescriptor
            {
                Issuer = _tokenConfigurations.Issuer,
                Audience = _tokenConfigurations.Audience,
                SigningCredentials = _signingConfigurations.SigningCredentials,
                Subject = identity,
                NotBefore = createDate,
                Expires = expirationDate
            });

            var token = handler.WriteToken(securityToken);
            return token;
        }

        private object SuccesObject(LoginDto user, string token, DateTime createDate, DateTime expirationDate)
        {
            return new
            {
                authenticated = true,
                created = createDate.ToString("yyyy-MM-dd HH:mm:ss"),
                expiration = expirationDate.ToString("yyyy-MM-dd HH:mm:ss"),
                acessToken = token,
                userName = user.Email,
                message = "Usuário logado com sucesso."
            };
        }
    }
}
