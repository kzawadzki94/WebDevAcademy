using HashidsNet;
using WebDevAcademy.UrlShortener.Models;

namespace WebDevAcademy.UrlShortener.Utils
{
    public static class UrlShortenerUtil
    {
        public static Url Shorten(Url url)
        {
            var hashids = new Hashids(salt: url.LongUrl, minHashLength: 6);
            url.ShortUrl = hashids.Encode(url.Id);

            return url;
        }
    }
}