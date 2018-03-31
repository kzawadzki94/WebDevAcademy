using Microsoft.EntityFrameworkCore;
using WebDevAcademy.UrlShortener.Models;

namespace WebDevAcademy.UrlShortener.Data
{
    public class UrlContext : DbContext
    {
        public UrlContext(DbContextOptions<UrlContext> options)
            : base(options)
        {
        }

        public DbSet<Url> Urls { get; set; }
    }
}