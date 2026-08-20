using Microsoft.AspNetCore.Mvc;

namespace ConsoleApp2.Service.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return Ok("Hello world ConsoleApp2");
        }
    }
}
