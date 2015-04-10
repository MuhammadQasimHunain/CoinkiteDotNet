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
            var timestamp = DateTime.UtcNow.ToString("s", System.Globalization.CultureInfo.InvariantCulture);

            var data = endpoint + "|" + timestamp;

            string hash = Crypto.HMACSha256(api_secret, data);

            Header htstamp = new Header { Name = "X-CK-Timestamp", Data = timestamp };
            Header hsign = new Header { Name = "X-CK-Sign", Data = hash };
            List<Header> toReturn = new List<Header> {};
            toReturn.Add(htstamp);
            toReturn.Add(hsign);

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
