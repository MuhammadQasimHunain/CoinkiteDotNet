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

        public Accounts accounts()
        {
            HttpResponseMessage result = Requests.sendRequest(null, "/v1/my/accounts", api_key, api_secret);

            return JsonConvert.DeserializeObject<Accounts>(result.Content.ReadAsStringAsync().Result);
        }

        public Accounts allaccounts()
        {
            HttpResponseMessage result = Requests.sendRequest(null, "/v1/my/all_accounts", api_key, api_secret);

            return JsonConvert.DeserializeObject<Accounts>(result.Content.ReadAsStringAsync().Result);
        }

        public Cards cards()
        {
            HttpResponseMessage result = Requests.sendRequest(null, "/v1/my/cards", api_key, api_secret);

            return JsonConvert.DeserializeObject<Cards>(result.Content.ReadAsStringAsync().Result);
        }

        public Emails emails()
        {
            HttpResponseMessage result = Requests.sendRequest(null, "/v1/my/emails", api_key, api_secret);

            return JsonConvert.DeserializeObject<Emails>(result.Content.ReadAsStringAsync().Result);
        }

        public Phones phonenumbers()
        {
            HttpResponseMessage result = Requests.sendRequest(null, "/v1/my/phone_numbers", api_key, api_secret);

            return JsonConvert.DeserializeObject<Phones>(result.Content.ReadAsStringAsync().Result);
        }

        public Invoices invoices()
        {
            HttpResponseMessage result = Requests.sendRequest(null, "/v1/my/invoices", api_key, api_secret);

            return JsonConvert.DeserializeObject<Invoices>(result.Content.ReadAsStringAsync().Result);
        }

        public Revshares revshares()
        {
            HttpResponseMessage result = Requests.sendRequest(null, "/v1/my/revshare", api_key, api_secret);

            return JsonConvert.DeserializeObject<Revshares>(result.Content.ReadAsStringAsync().Result);
        }

        public SentEmails sentemails()
        {
            HttpResponseMessage result = Requests.sendRequest(null, "/v1/my/sent_emails", api_key, api_secret);

            return JsonConvert.DeserializeObject<SentEmails>(result.Content.ReadAsStringAsync().Result);
        }

        public SentTexts sentsms()
        {
            HttpResponseMessage result = Requests.sendRequest(null, "/v1/my/sent_sms", api_key, api_secret);

            return JsonConvert.DeserializeObject<SentTexts>(result.Content.ReadAsStringAsync().Result);
        }

        public Vouchers vouchers()
        {
            HttpResponseMessage result = Requests.sendRequest(null, "/v1/my/vouchers", api_key, api_secret);

            return JsonConvert.DeserializeObject<Vouchers>(result.Content.ReadAsStringAsync().Result);
        }

        public Terminals terminals()
        {
            HttpResponseMessage result = Requests.sendRequest(null, "/v1/my/terminals", api_key, api_secret);

            return JsonConvert.DeserializeObject<Terminals>(result.Content.ReadAsStringAsync().Result);
        }

        public Terminals allterminals()
        {
            HttpResponseMessage result = Requests.sendRequest(null, "/v1/my/all_terminals", api_key, api_secret);

            return JsonConvert.DeserializeObject<Terminals>(result.Content.ReadAsStringAsync().Result);
        }

        public Nyms nyms()
        {
            HttpResponseMessage result = Requests.sendRequest(null, "/v1/my/active_nyms", api_key, api_secret);

            return JsonConvert.DeserializeObject<Nyms>(result.Content.ReadAsStringAsync().Result);
        }

        public Nyms allnyms()
        {
            HttpResponseMessage result = Requests.sendRequest(null, "/v1/my/nyms", api_key, api_secret);

            return JsonConvert.DeserializeObject<Nyms>(result.Content.ReadAsStringAsync().Result);
        }

        public Details getdetails(string CK_refnum)
        {
            string url = "/v1/detail/" + CK_refnum;

            HttpResponseMessage result = Requests.sendRequest(null, url, api_key, api_secret);

            return JsonConvert.DeserializeObject<Details>(result.Content.ReadAsStringAsync().Result);
        }
        //result.Content.ReadAsStringAsync().Result;
    }
}
