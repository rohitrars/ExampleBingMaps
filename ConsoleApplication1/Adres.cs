using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    public class Adres
    {
        private string _straat;
        private string _nummer;
        private string _postcode;
        private string _gemeente;

        public Adres() { }
        public Adres(string postcode, string gemeente)
        {
            this._postcode = postcode;
            this._gemeente = gemeente;
        }
        public Adres(string straat, string nummer, string postcode, string gemeente)
        {
            this._straat = straat;
            this._nummer = nummer;
            this._postcode = postcode;
            this._gemeente = gemeente;
        }

        public string Straat { get { return this._straat; } set { this._straat = value; } }
        public string Nummer { get { return this._nummer; } set { this._nummer = value; } }
        public string Postcode { get { return this._postcode; } set { this._postcode = value; } }
        public string Gemeente { get { return this._gemeente; } set { this._gemeente = value; } }
    }
}
