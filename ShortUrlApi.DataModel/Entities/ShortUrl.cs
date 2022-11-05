using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShortUrlApi.DataModel.Entities
{
    public class ShortUrl
    {
        [Key]
        public Guid ShortUrlId { get; set; }

        public string OrginalUrl { get; set; } = null!;

        public string ShortenerUrl { get; set; } = null!;

        public int UsedUrlCount { get; set; }
    }
}
