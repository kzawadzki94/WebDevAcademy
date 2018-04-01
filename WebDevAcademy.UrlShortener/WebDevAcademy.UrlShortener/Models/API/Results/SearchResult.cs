using System.Collections.Generic;

namespace WebDevAcademy.UrlShortener.Models.API.Results
{
    public class SearchResult
    {
        public IEnumerable<LinkResult> Items { get; set; }
        public PageInfo PageInfo { get; set; }
    }

    public class PageInfo
    {
        public int CurrentPage { get; set; }

        public int MaxPage { get; set; }
    }

    public class LinkResult
    {
        public LinkResult(Url url)
        {
            Id = url.Id;
            LongUrl = url.LongUrl;
            ShortUrl = url.ShortUrl;
        }

        public int Id { get; set; }
        public string LongUrl { get; set; }
        public string ShortUrl { get; set; }
    }
}