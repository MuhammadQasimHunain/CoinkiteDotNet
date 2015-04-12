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
    }
}
