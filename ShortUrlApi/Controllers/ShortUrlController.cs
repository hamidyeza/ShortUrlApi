using Microsoft.AspNetCore.Mvc;
using ShortUrlApi.DataModel.Services;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ShortUrlApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ShortUrlController : ControllerBase
    {
       private readonly IShortUrlRepository _shortUrlRepository;

        public ShortUrlController(IShortUrlRepository shortUrlRepository)
        {
            _shortUrlRepository = shortUrlRepository;
        }



        // GET: api/<ShortUrlController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<ShortUrlController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<ShortUrlController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

    }
}
