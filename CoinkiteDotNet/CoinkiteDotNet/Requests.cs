using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;


namespace CoinkiteDotNet
{
    class Requests
    {
        async Task<HttpResponseMessage> sendRequest(List<Header> headers, string endpoint, string api_key, string api_secret)
        {
            try
            {
                using (var client = new HttpClient())
                {
                    string sig;
                    string tstamp;

                    foreach(Header header in Helpers.sign(endpoint, api_secret))
                    {
                        headers.Add(header);
                    }

                    client.BaseAddress = new Uri("https://api.coinkite.com");
                    client.DefaultRequestHeaders.Accept.Clear();
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                    client.DefaultRequestHeaders.Add("X-CK-Key", api_key);

                    foreach (Header header in headers)
                    {
                        client.DefaultRequestHeaders.Add(header.Name, header.Data);
                    }

                    HttpResponseMessage response = await client.GetAsync(endpoint);

                    return response;
                    
                }
            }
            catch
            {
                throw;
            }
            
        }
    }
}
