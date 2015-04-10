using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;
using System.Net.Http.Headers;


namespace CoinkiteDotNet
{
    class Requests
    {
        public static HttpResponseMessage sendRequest(List<Header> headers, string endpoint, string api_key, string api_secret)
        {
            
            using (var client = new HttpClient())
            {
                List<Header> headerlist = new List<Header>{};

                if(headers != null)
                    headerlist = headers;
                
                List<Header> signed = Helpers.sign(endpoint, api_secret);
                foreach (Header header in signed)
                {
                    headerlist.Add(header);
                }

                client.BaseAddress = new Uri("https://api.coinkite.com");
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                client.DefaultRequestHeaders.Add("X-CK-Key", api_key);

                foreach (Header header in headerlist)
                {
                    client.DefaultRequestHeaders.Add(header.Name, header.Data);
                }

                HttpResponseMessage response = client.GetAsync(endpoint).Result;

                return response;
                    
            }
            
            
        }
        
    }
}
