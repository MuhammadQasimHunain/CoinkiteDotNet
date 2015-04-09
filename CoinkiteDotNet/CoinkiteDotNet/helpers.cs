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
        public static List<Header> sign(string endpoint, string api_secret)
        {
            var timestamp = Convert.ToString((Int32)(DateTime.UtcNow.Subtract(new DateTime(1970, 1, 1))).TotalSeconds);
            var data = endpoint + "|" + timestamp;

            string hash = Crypto.HMACSha256(api_secret, data);

            List<Header> toReturn = new List<Header> { new Header{Name = "X-CK-Timestamp",Data = timestamp}, new Header{Name = "X-CK-Sign", Data = hash} };

            return toReturn;
        }

        public static int toSatoshi(decimal btc)
        {
            return Convert.ToInt32(btc * 10000000);
        }

        public static decimal toBtc(int satoshi)
        {
            return Convert.ToDecimal(satoshi/10000000);
        }
    }
}
