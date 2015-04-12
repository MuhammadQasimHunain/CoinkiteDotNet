using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoinkiteDotNet
{
    class Header
    {
        public string Name { get; set; }
        public string Data { get; set; }
    }

    public class ApiKey
    {
        public string CK_refnum { get; set; }
        public string CK_type { get; set; }
        public string api_key { get; set; }
        public object funds_limit { get; set; }
        public int max_request_rate { get; set; }
        public string memo { get; set; }
        public List<string> permissions { get; set; }
        public object source_ip { get; set; }
    }

    public class MySelf
    {
        public ApiKey api_key { get; set; }
        public string member_since { get; set; }
        public string membership { get; set; }
        public List<string> nyms { get; set; }
        public Dictionary<string,string> supported_cct { get; set; }
        public string username { get; set; }
    }
}
