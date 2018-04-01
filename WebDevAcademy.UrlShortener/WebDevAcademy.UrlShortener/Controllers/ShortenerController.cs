using Microsoft.AspNetCore.Mvc;
using System;
using WebDevAcademy.UrlShortener.Interfaces;
using WebDevAcademy.UrlShortener.Models;
using WebDevAcademy.UrlShortener.Utils;

namespace WebDevAcademy.UrlShortener.Controllers
{
    public class ShortenerController : UrlShortenerControllerBase
    {
        public ShortenerController(IUrlRepository repository) : base(repository)
        {
        }

        [HttpGet]
        public IActionResult Index()
            => View(_repository.GetAll());

        [HttpPost]
        public IActionResult Shorten(Url url)
        {
            if (Uri.IsWellFormedUriString(url.LongUrl, UriKind.RelativeOrAbsolute))
            {
                _repository.Add(UrlShortenerUtil.Shorten(url));
                return Redirect("Index");
            }
            return BadRequest("Given URL is not valid");
        }

        [HttpGet]
        public IActionResult Delete(Url url)
        {
            _repository.Delete(url.Id);
            return Redirect("Index");
        }

        [HttpGet]
        public IActionResult Edit(Url url)
        {
            return View(url);
        }

        [HttpPost]
        public IActionResult Update(Url url)
        {
            _repository.Update(url);
            return Redirect("Index");
        }
    }
}