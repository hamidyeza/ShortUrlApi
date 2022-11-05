using ShortUrlApi.DataModel.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShortUrlApi.DataModel.Services
{
    public interface IShortUrlRepository
    {
        Task<ShortUrlDto> CreateShortUrlAsync(string originalUrl);

        Task<ShortUrlDto> GetShortUrlAsync(string shortUrl);

        Task<bool> CheckIsExistUrlAsync(string orginalUrl);

        Task IncrementUsedUrlAsync(string shortUrl);

        Task<int> GetUrlUsedCount(string shortUrl);
    }
}
