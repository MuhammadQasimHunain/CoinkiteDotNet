using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CoinkiteDotNet;

namespace TestClient
{
    class Program
    {
        static void Main(string[] args)
        {
            ICoinKite test = new ICoinKiteService("K4b092859-55e83adc-de62977147d346f4", "S097472f9-a831bd74-d730c43d58b79652");
            Details output = test.getdetails("378E48776C-2C27E1");

            System.Console.WriteLine(output.detail.CK_type);
            System.Console.ReadLine();
        }
    }
}
