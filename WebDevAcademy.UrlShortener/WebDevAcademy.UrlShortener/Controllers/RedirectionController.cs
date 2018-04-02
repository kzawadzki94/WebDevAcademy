using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebDevAcademy.UrlShortener.Interfaces;
using WebDevAcademy.UrlShortener.Utils;

namespace WebDevAcademy.UrlShortener.Controllers
{
    [Route("")]
    public class RedirectionController : UrlShortenerControllerBase
    {
        private IHttpContextAccessor _httpContextAccessor;

        public RedirectionController(IUrlRepository repository, IHttpContextAccessor httpContextAccessor) : base(repository)
        {
            _httpContextAccessor = httpContextAccessor;
        }

        [HttpGet("{hash}")]
        public IActionResult Index(string hash)
        {
            if (string.IsNullOrEmpty(hash))
                return Redirect("Shortener");

            var urlToRedirect = _repository.Get(hash);

            if (urlToRedirect == null)
                return NotFound("Site not found!");

            if (UniqueVisitsCookieUtil.ReadCookie(_httpContextAccessor, urlToRedirect) != "Visited")
            {
                UniqueVisitsCookieUtil.WriteCookie(_httpContextAccessor, urlToRedirect);
                urlToRedirect.UniqueVisits += 1;
                _repository.Update(urlToRedirect);
            }
            if (urlToRedirect.LongUrl.Contains("http://") || urlToRedirect.LongUrl.Contains("https://"))
                return Redirect(urlToRedirect.LongUrl);
            else
                return Redirect($"http://{urlToRedirect.LongUrl}");
        }
    }
}