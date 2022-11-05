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

        public Task<bool> CheckIsExistUrlAsync(string orginalUrl)
        {
            throw new NotImplementedException();
        }

        public Task<ShortUrlDto> CreateShortUrlAsync(string originalUrl)
        {
            throw new NotImplementedException();
        }

        public Task<ShortUrlDto> GetShortUrlAsync(string shortUrl)
        {
            throw new NotImplementedException();
        }

        public Task<int> GetUrlUsedCount(string shortUrl)
        {
            throw new NotImplementedException();
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
