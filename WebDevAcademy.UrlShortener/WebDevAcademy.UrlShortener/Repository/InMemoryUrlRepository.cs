using System;
using System.Collections.Generic;
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

        public List<Url> GetAll()
            => _urlsList;

        public void Add(Url url)
        {
            url.Id = _urlsList.Count;
            _urlsList.Add(url);
        }
    }
}