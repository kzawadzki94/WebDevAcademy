using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebDevAcademy.UrlShortener.Models
{
    public class Url
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string LongUrl { get; set; }
        public string ShortUrl { get; set; }
    }
}