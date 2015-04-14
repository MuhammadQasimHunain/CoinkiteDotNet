using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Windows.Forms;


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
            User toreturn = new User();

            string csrf;

            WebBrowser webcontrol = new WebBrowser();

            webcontrol.AllowNavigation = true;
            webcontrol.ScriptErrorsSuppressed = true;
            webcontrol.Navigate("https://coinkite.com/signup");
            webcontrol.DocumentCompleted += new WebBrowserDocumentCompletedEventHandler(webcontrol_DocumentCompleted);

            HtmlElementCollection forms = webcontrol.Document.GetElementById("csrf_token").GetElementsByTagName("value");

            string tosend = forms[0].InnerText;
            toreturn.apikey = tosend;
            return toreturn;
        }

        private static void webcontrol_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {
            
        }
        
    }
}
