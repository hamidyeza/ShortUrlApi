using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace ShortUrlApi.CommonLayer.Helper
{
    public class UrlHelper
    {
        public static string GetUriLeftPart(string uri)
        {
            return new Uri(uri).GetLeftPart(UriPartial.Authority);
        }
        public static string GetShortUri(string host, int tokenLength = 16)
        {
            var rnd = new RNGCryptoServiceProvider();
            var tokenBytes = new byte[tokenLength];
            rnd.GetBytes(tokenBytes);
            var token =
                tokenBytes
                    .Select(b => UriConstants.TOKENALPHABET[b % UriConstants.TOKENALPHABET.Length])
                    .ToArray();

            return host + "/" + new string(token);
        }
    }
}
