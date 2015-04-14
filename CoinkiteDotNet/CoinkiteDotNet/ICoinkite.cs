using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoinkiteDotNet
{
    public interface ICoinKite
    {
        MySelf self();
        ApiKeys apikeys();
        Accounts accounts();
        Accounts allaccounts();
        Cards cards();
        Emails emails();
        Phones phonenumbers();
        Invoices invoices();
        Revshares revshares();
        SentEmails sentemails();
        SentTexts sentsms();
        Vouchers vouchers();
        Terminals terminals();
        Terminals allterminals();
        Nyms nyms();
        Nyms allnyms();
        Details getdetails(string CK_refnum);
        User registerUser();
    }
}
