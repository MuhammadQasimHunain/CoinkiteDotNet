using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Windows.Forms;
using System.Threading;


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

        public static User registerUser()
        {
            Uri test = new Uri("https://www.coinkite.com/signup");
            HtmlDocument testdoc = runBrowserThread(test);

            string tosend = "test";

            User user = new User();

            user.apikey = tosend;

            return user;

        }
        public static HtmlDocument runBrowserThread(Uri url)
        {
            HtmlDocument value = null;
            var th = new Thread(() =>
            {
                var br = new WebBrowser();
                br.DocumentCompleted += browser_DocumentCompleted;
                br.Navigate(url);
                value = br.Document;
                Application.Run();
            });
            th.SetApartmentState(ApartmentState.STA);
            th.Start();
            th.Join(8000); 
            return value;
        }

        static void browser_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {
            var br = sender as WebBrowser;
            if (br.Url == e.Url)
            {
                Console.WriteLine("Natigated to {0}", e.Url);
                Console.WriteLine(br.Document.Body.InnerHtml);
                System.Console.ReadLine();
                Application.ExitThread();   // Stops the thread
            }
        }
        
    }
}
