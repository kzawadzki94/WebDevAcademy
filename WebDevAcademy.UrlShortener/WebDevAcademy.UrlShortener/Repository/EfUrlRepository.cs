using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using WebDevAcademy.UrlShortener.Data;
using WebDevAcademy.UrlShortener.Interfaces;
using WebDevAcademy.UrlShortener.Models;

namespace WebDevAcademy.UrlShortener.Repository
{
    public class EfUrlRepository : IUrlRepository
    {
        private readonly UrlContext _db;

        public EfUrlRepository(UrlContext urlContext)
        {
            _db = urlContext;
        }

        public string GetLongUrl(string hash)
        {
            var searchedItem = _db.Urls.Where(item => item.ShortUrl.Equals(hash)).FirstOrDefault();

            if (searchedItem == null)
                return string.Empty;

            return searchedItem.LongUrl;
        }

        public List<Url> GetAll()
            => _db.Urls.ToList();

        public void Add(Url url)
        {
            _db.Urls.Add(url);
            _db.SaveChanges();
        }

        public void Delete(Url url)
        {
            var urlToRemove = _db.Urls.Where(item => item.Id.Equals(url.Id)).SingleOrDefault();
            _db.Urls.Remove(urlToRemove);
            _db.SaveChanges();
        }

        public void Update(Url url)
        {
            _db.Urls.Add(url);
            _db.Entry(url).State = EntityState.Modified;
            _db.SaveChanges();
        }
    }
}