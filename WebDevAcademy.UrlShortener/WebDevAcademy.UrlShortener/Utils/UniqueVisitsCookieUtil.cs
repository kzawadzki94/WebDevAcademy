using Microsoft.AspNetCore.Http;
using System;
using WebDevAcademy.UrlShortener.Models;

namespace WebDevAcademy.UrlShortener.Utils
{
    public static class UniqueVisitsCookieUtil
    {
        public static void WriteCookie(IHttpContextAccessor httpContextAccessor, Url url)
        {
            var options = new CookieOptions();
            options.Expires = DateTime.Now.AddDays(1);
            httpContextAccessor.HttpContext.Response.Cookies.Append(url.ShortUrl, "Visited", options);
        }

        public static string ReadCookie(IHttpContextAccessor httpContextAccessor, Url url)
            => httpContextAccessor.HttpContext.Request.Cookies[url.ShortUrl];
    }
}