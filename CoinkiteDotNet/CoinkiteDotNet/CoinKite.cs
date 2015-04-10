using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoinkiteDotNet
{
    public class ICoinKiteService : ICoinKite
    {
        private string api_key;
        private string api_secret;

        public ICoinKiteService(string api_key, string api_secret)
        {
            this.api_key = api_key;
            this.api_secret = api_secret;
        }

    }
}
