using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Net;


namespace CoinkiteDotNet
{
    class Requests
    {
        public static string sendRequest(List<Header> headers, string endpoint, string api_key, string api_secret)
        {
            try
            {
                using (var client = new WebClient())
                {
                    
                    foreach(Header header in Helpers.sign(endpoint, api_secret))
                    {
                        headers.Add(header);
                    }

                    client.BaseAddress = "https://api.coinkite.com";
                    client.Headers.Clear();
                    client.Headers.Add("X-CK-Key", api_key);

                    foreach (Header header in headers)
                    {
                        client.Headers.Add(header.Name, header.Data);
                    }

                    string response = client.DownloadString(endpoint);

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
