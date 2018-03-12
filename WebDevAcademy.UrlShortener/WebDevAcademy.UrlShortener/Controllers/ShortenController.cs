using Microsoft.AspNetCore.Mvc;

namespace WebDevAcademy.UrlShortener.Controllers
{
    public class ShortenController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}