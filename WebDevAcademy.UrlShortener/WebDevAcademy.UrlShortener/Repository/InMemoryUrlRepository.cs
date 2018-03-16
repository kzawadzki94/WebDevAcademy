using System.Collections.Generic;
using System.Linq;
using WebDevAcademy.UrlShortener.Interfaces;
using WebDevAcademy.UrlShortener.Models;

namespace WebDevAcademy.UrlShortener.Repository
{
    public class InMemoryUrlRepository : IUrlRepository
    {
        private List<Url> _urlsList;

        public InMemoryUrlRepository()
        {
            _urlsList = new List<Url>();
        }

        public string GetLongUrl(string hash)
        {
            var searchedItem = _urlsList.Where(item => item.ShortUrl.Equals(hash)).FirstOrDefault();

            if (searchedItem == null)
                return string.Empty;

            return searchedItem.LongUrl;
        }

        public List<Url> GetAll()
            => _urlsList;

        public void Add(Url url)
        {
            url.Id = _urlsList.Count;
            _urlsList.Add(url);
        }
    }
}