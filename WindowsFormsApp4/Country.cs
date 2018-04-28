using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp4
{
    internal class Country
    {
        internal string CountryCode;
        internal string CountryName;
        public Country(string cc, string cn)
        {
            CountryCode = cc;
            CountryName = cn;
        }
        internal List<Airports> airports = new List<Airports>();
    }
}
