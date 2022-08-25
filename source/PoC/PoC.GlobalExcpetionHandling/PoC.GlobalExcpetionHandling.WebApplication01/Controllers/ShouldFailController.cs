using Microsoft.AspNetCore.Mvc;

namespace PoC.GlobalExcpetionHandling.WebApplication01.Controllers
{
    public class ShouldFailController : Controller
    {
        public IActionResult Index()
        {
            throw new Exception("Something really bad happened");
            return View();
        }
    }
}
