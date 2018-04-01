using WebDevAcademy.UrlShortener.Utils;

namespace WebDevAcademy.UrlShortener.Models.API.Requests
{
    public class ShortenLinkRequest
    {
        public string LongUrl { get; set; }

        public Url GetUrl()
        {
            return UrlShortenerUtil.Shorten(new Url
            {
                LongUrl = this.LongUrl
            });
        }
    }
}