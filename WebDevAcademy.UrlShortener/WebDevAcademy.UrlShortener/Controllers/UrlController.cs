using Microsoft.AspNetCore.Mvc;
using WebDevAcademy.UrlShortener.Interfaces;

namespace WebDevAcademy.UrlShortener.Controllers
{
    public class UrlController : Controller
    {
        private IUrlRepository _repository;

        public UrlController(IUrlRepository repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public IActionResult Index()
            => View(_repository.GetAll());

        [HttpPost]
        public IActionResult Shorten()
        {
            return Redirect("Index");
        }
    }
}