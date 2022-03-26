using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank
{
    class Credit
    {
        public int code { get; }
        public int client_code { get; }
        public int bank_account { get; }
        public int currency { get; }
        public int sum { get; }
        public int percent { get; }
        public DateTime start { get; }
        public DateTime end { get; }
    }
}
