using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;

namespace CoinkiteDotNet
{
    class Helpers
    {
        public static Dictionary<string,string> sign(string endpoint, string api_secret)
        {
            var timestamp = Convert.ToString((Int32)(DateTime.UtcNow.Subtract(new DateTime(1970, 1, 1))).TotalSeconds);
            var data = endpoint + "|" + timestamp;

            string hash = Crypto.HMACSha256(api_secret, data);

            Dictionary<string, string> toReturn = new Dictionary<string, string> { { "timestamp", timestamp }, { "signature", hash } };

            return toReturn;
        }
    }
}
