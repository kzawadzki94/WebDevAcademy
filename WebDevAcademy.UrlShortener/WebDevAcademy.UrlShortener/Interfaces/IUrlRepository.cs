using System.Collections.Generic;
using WebDevAcademy.UrlShortener.Models;

namespace WebDevAcademy.UrlShortener.Interfaces
{
    public interface IUrlRepository
    {
        Url Get(int id);

        (IEnumerable<Url>, int) Get(string search, int skip, int itemsPerPage);

        Url Get(string hash);

        List<Url> GetAll();

        Url Add(Url url);

        void Delete(int id);

        Url Update(Url url);
    }
}