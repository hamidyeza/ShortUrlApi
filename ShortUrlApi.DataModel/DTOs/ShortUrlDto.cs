using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShortUrlApi.DataModel.DTOs
{
    public class ShortUrlDto
    {
        public string OrginalUrl { get; set; } = null!;

        public string ShortenerUrl { get; set; } = null!;
    }
}
