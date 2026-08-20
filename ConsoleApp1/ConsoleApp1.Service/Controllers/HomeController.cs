using Microsoft.AspNetCore.Mvc;

namespace ConsoleApp1.Service.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return Ok("Hello world ConsoleApp1");
        }
    }
}
