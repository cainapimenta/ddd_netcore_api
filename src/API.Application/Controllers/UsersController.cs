using Microsoft.AspNetCore.Mvc;

namespace API.Application.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
