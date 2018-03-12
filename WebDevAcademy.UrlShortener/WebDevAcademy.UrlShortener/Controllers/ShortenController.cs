using Microsoft.AspNetCore.Mvc;

namespace WebDevAcademy.UrlShortener.Controllers
{
    public class ShortenController : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult ShortenUrl()
        {
            return Index();
        }
    }
}