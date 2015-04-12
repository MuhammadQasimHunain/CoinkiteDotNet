using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

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

        public MySelf self()
        {
            HttpResponseMessage result = Requests.sendRequest(null, "/v1/my/self", api_key, api_secret);

            return JsonConvert.DeserializeObject<MySelf>(result.Content.ReadAsStringAsync().Result);
        }

        public ApiKeys apikeys()
        {
            HttpResponseMessage result = Requests.sendRequest(null, "/v1/my/api_keys", api_key, api_secret);

            return JsonConvert.DeserializeObject<ApiKeys>(result.Content.ReadAsStringAsync().Result);
        }
    }
}
