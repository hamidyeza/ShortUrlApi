using Microsoft.AspNetCore.Mvc;
using ShortUrlApi.DataModel.DTOs;
using ShortUrlApi.DataModel.Services;
using System;

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



        [Route("get")]
        [HttpGet]
        public async Task<IActionResult> Get(string url)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(url))
                    return BadRequest();
                var shortUrl = await _shortUrlRepository.GetShortUrlAsync(url);
                return Ok(shortUrl);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }



        [Route("create")]
        [HttpPost]
        public async Task<IActionResult> CreateShortUrl([FromBody] string orginalUrl)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(orginalUrl))
                    return BadRequest();
                var shortUrl = await _shortUrlRepository.CreateShortUrlAsync(orginalUrl);
                return Ok(shortUrl);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

    }
}
