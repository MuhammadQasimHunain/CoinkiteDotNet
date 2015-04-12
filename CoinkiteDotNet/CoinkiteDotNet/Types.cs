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
    public class Paging
    {
        public int count_here { get; set; }
        public int limit { get; set; }
        public int offset { get; set; }
        public int total_count { get; set; }
    }

    public class ApiKeys
    {
        public Paging paging { get; set; }
        public List<ApiKey> results { get; set; }
    }

    public class SubAccount
    {
        public string CK_acct_type { get; set; }
        public string CK_refnum { get; set; }
        public string CK_type { get; set; }
        public string coin_type { get; set; }
        public bool is_closed { get; set; }
        public string name { get; set; }
        public int subaccount { get; set; }
    }

    public class Accounts
    {
        public Paging paging { get; set; }
        public List<SubAccount> results { get; set; }
    }

    public class QR
    {
        public string address { get; set; }
        public string coin_type { get; set; }
        public string is_card { get; set; }//will it work as a bool? we may never know
    }

    public class Card
    {
        public string CK_refnum { get; set; }
        public string CK_type { get; set; }
        public string is_locked { get; set; }//will these work as bool? Need a test card to find out
        public string is_lost { get; set; } //as above, so below
        public string number { get; set; }
        public QR rear_qr { get; set; }
    }

    public class Cards
    {
        public Paging paging { get; set; }
        public List<Card> results { get; set; }
    }

    public class Email
    {
        public string CK_refnum { get; set; }
        public string CK_type { get; set; }
        public string address { get; set; }
        public string priority { get; set; } //I have no clue what type this returns
        public string verified { get; set; } //nor this
    }

    public class Emails
    {
        public Paging paging { get; set; }
        public List<Email> results { get; set; }
    }

    public class Phone
    {
        public string CK_refnum { get; set; }
        public string CK_type { get; set; }
        public string number { get; set; }
        public string number_e164 { get; set; }
    }

    public class Phones
    {
        public Paging paging { get; set; }
        public List<Phone> results { get; set; }
    }

    public class Invoice
    {
        public string CK_refnum { get; set; }
        public string CK_type { get; set; }
        public string coin_type { get; set; }
        public string description { get; set; }
        public string is_paid { get; set; }
        public string total { get; set; }
    }

    public class Invoices
    {
        public Paging paging { get; set; }
        public List<Invoice> results { get; set; }
    }

    public class Revshare
    {
        public string CK_refnum { get; set; }
        public string CK_type { get; set; }
        public string is_friend { get; set; }
        public string is_reseller { get; set; }
        public string memo { get; set; }
        public string short_code { get; set; }
        public string url { get; set; }
    }

    public class Revshares
    {
        public Paging paging { get; set; }
        public List<Revshare> results { get; set; }
    }

    public class SentEmail
    {
        public string CK_refnum { get; set; }
        public string CK_type { get; set; }
        public string template { get; set; }
        public string to { get; set; }
        public string public_msg { get; set; }
        public string failed { get; set; }
        public string sent_at { get; set; }
        public string delivered_at { get; set; }
    }

    public class SentEmails
    {
        public Paging paging { get; set; }
        public List<SentEmail> results { get; set; }
    }

    public class SentText
    {
        public string CK_refnum { get; set; }
        public string CK_type { get; set; }
        public string number { get; set; }
        public string number_e164 { get; set; }
        public string template { get; set; }
        public string message_body { get; set; }
        public string public_msg { get; set; }
        public string failed { get; set; }
        public string sent_at { get; set; }
        public string delivered_at { get; set; }
    }

    public class SentTexts
    {
        public Paging paging { get; set; }
        public List<SentText> results {get; set;}
    }

    public class Coin
    {
        public string address { get; set; }
        public string coin_type { get; set; }
        public string is_voucher { get; set; }
    }

    public class Voucher
    {
        public string CK_refnum { get; set; }
        public string CK_type { get; set; }
        public string amount { get; set; }
        public string coin_type { get; set; }
        public string claimed_at { get; set; }
        public Coin coin { get; set; }
        public string detail_page { get; set; }
        public string pin_code { get; set; }
        public string voucher_code { get; set; }
        public string sent_messages { get; set; }
    }

    public class Vouchers
    {
        public Paging paging { get; set; }
        public List<Voucher> results { get; set; }
    }

    public class Terminal
    {
        public string CK_refnum { get; set; }
        public string CK_type { get; set; }
        public string detail_page { get; set; }
        public string guid { get; set; }
        public string name { get; set; }
        public string serial { get; set; }
        public string is_wiped { get; set; }
    }

    public class Terminals
    {
        public Paging paging { get; set; }
        public List<Terminal> results { get; set; }
    }

    public class Nym
    {
        public string CK_refnum { get; set; }
        public string CK_type { get; set; }
        public string profile_url { get; set; }
        public string detail_url { get; set; }
        public string display_name { get; set; }
        public string nym_name { get; set; }
        public string subtitle { get; set; }
        public string email_md5 { get; set; }
        public string image_url { get; set; }
        public bool is_active { get; set; }
        public bool is_searchable { get; set; }
        public string message { get; set; }
        public Dictionary<string, string> payments { get; set; }
        public string twitter { get; set; }
        public string updated_at { get; set; }
        public string website { get; set; }
        public int num_favs { get; set; }
    }

    public class Nyms
    {
        public Paging paging { get; set; }
        public List<Nym> results { get; set; }
    }
}
