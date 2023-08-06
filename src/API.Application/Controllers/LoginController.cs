using API.Domain.Dtos;
using API.Domain.Interfaces.Services.User;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Net;
using System.Threading.Tasks;

namespace API.Application.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly ILoginService _service;

        public LoginController(ILoginService service)
        {
            _service = service;
        }

        [HttpPost]
        public async Task<object> Login([FromBody] LoginDto login)
        {
            if(!ModelState.IsValid)
                return BadRequest(ModelState);

            if (login == null)
                return BadRequest();

            try
            {
                var result = await _service.FindByLogin(login);

                if (result == null)
                    return NotFound();
                else
                    return Ok(result);
            }
            catch (ArgumentException ex)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, ex.Message);
            }
            catch (Exception ex)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, ex.Message);
            }
        }
    }
}
