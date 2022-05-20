using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank
{
    public class Client
    {
        public string name { get;}
        public int code { get; }
        public int IPN { get; }
        public string email { get; }

        //constructor
        public Client(string new_name, int new_code, int new_IPN, string new_email)
        {
            this.name = new_name;
            this.code = new_code;
            this.IPN = new_IPN;
            this.email = new_email;
        }
    }
}
