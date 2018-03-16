using System.Collections.Generic;
using WebDevAcademy.UrlShortener.Models;

namespace WebDevAcademy.UrlShortener.Interfaces
{
    public interface IUrlRepository
    {
        string GetLongUrl(string hash);

        List<Url> GetAll();

        void Add(Url url);
    }
}