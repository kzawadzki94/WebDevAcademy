using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System.Linq;
using WebDevAcademy.UrlShortener.Interfaces;
using WebDevAcademy.UrlShortener.Models;
using WebDevAcademy.UrlShortener.Models.API.Requests;
using WebDevAcademy.UrlShortener.Models.API.Results;

namespace WebDevAcademy.UrlShortener.Controllers
{
    [Route("/api/links")]
    public class LinkApiController : UrlShortenerControllerBase
    {
        private readonly int ITEMS_PER_PAGE;

        public LinkApiController(IUrlRepository repository, IConfiguration configuration) : base(repository)
        {
            ITEMS_PER_PAGE = configuration.GetValue<int>("ApiSettings:ItemsPerPage");
        }

        // GET api/links/{id}
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var result = _repository.Get(id);

            if (result != null)
                return Ok(result);
            else
                return NotFound($"Could not find item with id = {id}");
        }

        // GET api/links/?search={string}&page={int}
        [HttpGet]
        public IActionResult Get([FromQuery] GetLinkRequest request)
        {
            var (links, count) = _repository.Get(request.Search, (request.Page.Value - 1) * ITEMS_PER_PAGE, ITEMS_PER_PAGE);

            var result = new SearchResult
            {
                PageInfo = new PageInfo
                {
                    CurrentPage = request.Page.Value,
                    MaxPage = count % ITEMS_PER_PAGE == 0 ? count / ITEMS_PER_PAGE : (count / ITEMS_PER_PAGE) + 1
                },
                Items = links.Select(l => new LinkResult(l))
            };
            return Ok(result);
        }

        // POST api/links
        [HttpPost]
        public IActionResult Post([FromBody] ShortenLinkRequest shortenLinkRequest)
            => Ok(_repository.Add(shortenLinkRequest.GetUrl()));

        // DELETE api/links/{id}
        [HttpDelete]
        public IActionResult Delete(int id)
        {
            _repository.Delete(id);
            return Ok();
        }

        // PUT api/links
        [HttpPut]
        public IActionResult Put([FromBody]Url url)
            => Ok(_repository.Update(url));
    }
}