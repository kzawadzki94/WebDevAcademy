using Microsoft.AspNetCore.Mvc;
using WebDevAcademy.UrlShortener.Interfaces;

namespace WebDevAcademy.UrlShortener.Controllers
{
    public abstract class UrlShortenerControllerBase : Controller
    {
        protected IUrlRepository _repository;

        public UrlShortenerControllerBase(IUrlRepository repository)
        {
            _repository = repository;
        }
    }
}