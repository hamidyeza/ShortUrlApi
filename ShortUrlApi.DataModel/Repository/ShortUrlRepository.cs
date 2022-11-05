using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using ShortUrlApi.CommonLayer.Helper;
using ShortUrlApi.DataModel.DTOs;
using ShortUrlApi.DataModel.Entities;
using ShortUrlApi.DataModel.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShortUrlApi.DataModel.Repository
{
    public class ShortUrlRepository : IShortUrlRepository
    {
        private readonly ApplicationDbContext _context;

        public ShortUrlRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<ShortUrlDto> CreateShortUrlAsync(string originalUrl)
        {
            var uriLeftPart = UrlHelper.GetUriLeftPart(originalUrl);
            var shortUri = UrlHelper.GetShortUri(uriLeftPart);

            ShortUrl url = new()
            {
                OrginalUrl = originalUrl,
                ShortenerUrl = shortUri,
                UsedUrlCount = 0,
                ShortUrlId = Guid.NewGuid()
            };

            await _context.ShortUrls.AddAsync(url);
            await _context.SaveChangesAsync();

            return new ShortUrlDto { ShortenerUrl = url.ShortenerUrl, OrginalUrl = url.OrginalUrl };
        }

        public async Task<ShortUrlDto> GetShortUrlAsync(string shortUrl)
        {
            ShortUrl? url = await _context.ShortUrls.Where(s => s.ShortenerUrl == shortUrl).FirstOrDefaultAsync();
            if (url == null)
                throw new Exception(ExceptionMessageConstants.UrlNotFound);
            await IncrementUsedUrlAsync(shortUrl);
            ShortUrlDto urlDto = new()
            {
                ShortenerUrl = url.ShortenerUrl,
                OrginalUrl = url.OrginalUrl
            };
            return urlDto;
        }

        public async Task<int> GetUrlUsedCount(string shortUrl)
        {
            ShortUrl? url = await _context.ShortUrls.Where(s => s.ShortenerUrl == shortUrl).FirstOrDefaultAsync();
            if (url != null)
                return url.UsedUrlCount;
            return 0;
        }

        public async Task IncrementUsedUrlAsync(string shortUrl)
        {
            ShortUrl? url = await _context.ShortUrls.Where(s => s.ShortenerUrl == shortUrl).FirstOrDefaultAsync();
            if (url != null)
            {
                url.UsedUrlCount++;
                _context.ShortUrls.Attach(url);
                _context.Entry(url).State = EntityState.Modified;
                await _context.SaveChangesAsync();
            }
        }
    }
}
