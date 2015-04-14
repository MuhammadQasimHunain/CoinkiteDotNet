using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;
using System.Net.Http.Headers;
using WatiN;
using WatiN.Core;
using System.Timers;



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
            
            using (var browser = new FireFox("https://www.coinkite.com/signup"))
            {
                browser.GoTo("https://coinkite.com/signup");
                browser.WaitForComplete();
                TextField username = browser.TextField(Find.ById("username"));
                TextField password = browser.TextField(Find.ById("password"));
                TextField password2 = browser.TextField(Find.ById("password2"));
                CheckBox toc = browser.CheckBox(Find.ById("accept_toc"));
                Button submit = browser.Button(Find.ByClass("btn btn-primary btn-large btn-block"));
                username.Value = "amigo3133";
                password.Value = "password";
                password2.Value = "password";
                toc.Click();
                submit.Click();

                System.Threading.Thread.Sleep(1500);

                browser.WaitForComplete();
                browser.GoTo("https://coinkite.com/welcome");
                
                browser.WaitUntilContainsText("Welcome");
                Button allset = browser.Button(Find.ByClass("js-sjbutton btn btn-primary btn-large btn-block btn-start"));
                allset.Click();
                System.Threading.Thread.Sleep(400);
                browser.GoToNoWait("https://coinkite.com/merchant/api");
                System.Threading.Thread.Sleep(550);
                Button createkey = browser.Button(Find.ByClass("js-sjmodal btn btn btn-primary"));
                createkey.Click();

                System.Threading.Thread.Sleep(300);

                Button submitkey = browser.Button(Find.ByText("Make"));
                submitkey.Click();

                browser.CheckBox(Find.ById("cap_recv")).Click();
                browser.CheckBox(Find.ById("cap_send")).Click();
                browser.CheckBox(Find.ById("cap_send2")).Click();
                browser.CheckBox(Find.ById("cap_xfer")).Click();
                browser.CheckBox(Find.ById("cap_term")).Click();
                browser.CheckBox(Find.ById("cap_events")).Click();
                browser.CheckBox(Find.ById("cap_acct")).Click();
                browser.CheckBox(Find.ById("cap_cosign")).Click();

                browser.Button(Find.ByClass("btn btn-large btn-primary")).Click();
                System.Threading.Thread.Sleep(1500);
                browser.GoTo("https://coinkite.com/logout");
                System.Threading.Thread.Sleep(300);
            }

            string tosend = "test";

            User user = new User();

            user.apikey = tosend;

            return user;

        }

        public static void TimerElapsed(object sender, ElapsedEventArgs e)
        {
            Console.WriteLine("timer");
        }

        
    }
}
