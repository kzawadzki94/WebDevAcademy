using Microsoft.AspNetCore.Mvc;
using WebDevAcademy.UrlShortener.Interfaces;

namespace WebDevAcademy.UrlShortener.Controllers
{
    [Route("")]
    public class RedirectionController : UrlShortenerControllerBase
    {
        public RedirectionController(IUrlRepository repository) : base(repository)
        {
        }

        [HttpGet("{hash}")]
        public IActionResult Index(string hash)
        {
            if (string.IsNullOrEmpty(hash))
            {
                return Redirect("Url");
            }

            var redirectionUrl = _repository.GetLongUrl(hash);

            if (string.IsNullOrEmpty(redirectionUrl))
                return NotFound("Site not found!");

            if (redirectionUrl.Contains("http://") || redirectionUrl.Contains("https://"))
                return Redirect(redirectionUrl);
            else
                return Redirect("http://" + redirectionUrl);
        }
    }
}