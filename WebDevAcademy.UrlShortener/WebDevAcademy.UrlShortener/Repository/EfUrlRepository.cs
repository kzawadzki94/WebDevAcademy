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

        public Url Get(int id)
            => _db.Urls.Where(u => u.Id == id).FirstOrDefault();

        public (IEnumerable<Url>, int) Get(string search, int skip, int itemsPerPage)
        {
            var filteredLinks = search != null ? _db.Urls
                .Where(l => l.LongUrl.ToLower()
                .Contains(search)) : _db.Urls;

            var linksCount = filteredLinks.Count();

            var paginatedLink = filteredLinks
                .OrderBy(l => l.Id)
                .Skip(skip)
                .Take(itemsPerPage);

            return (paginatedLink, linksCount);
        }

        public Url Get(string hash)
            => _db.Urls.Where(item => item.ShortUrl.Equals(hash)).FirstOrDefault();

        public List<Url> GetAll()
            => _db.Urls.ToList();

        public Url Add(Url url)
        {
            _db.Urls.Add(url);
            _db.SaveChanges();
            return url;
        }

        public void Delete(int id)
        {
            var urlToRemove = _db.Urls.Where(item => item.Id.Equals(id)).SingleOrDefault();
            _db.Urls.Remove(urlToRemove);
            _db.SaveChanges();
        }

        public Url Update(Url url)
        {
            _db.Urls.Attach(url);
            _db.Entry(url).State = EntityState.Modified;
            _db.SaveChanges();
            return url;
        }
    }
}