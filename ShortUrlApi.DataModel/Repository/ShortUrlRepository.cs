﻿using ShortUrlApi.DataModel.DTOs;
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

        public Task IncrementUsedUrlAsync(string shortUrl)
        {
            throw new NotImplementedException();
        }
    }
}