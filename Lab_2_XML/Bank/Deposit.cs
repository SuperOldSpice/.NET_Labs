using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank
{
    public class Deposit
    {
        public int code { get; }
        public int client_code { get; }
        public int bank_account { get; }
        public Currency currency { get; }
        public decimal sum { get; }
        public float percent { get; }
        public DateTime start { get; }
        public DateTime end { get; }

    //constructor
    public Deposit(int new_code, int new_client, int new_bank,
        Currency new_currency, decimal new_sum, float new_percent,
            DateTime new_start, DateTime new_end)
        {
            this.code = new_code;
            this.client_code = new_client;
            this.bank_account = new_bank;
            this.currency = new_currency;
            this.sum = new_sum;
            this.percent = new_percent;
            this.start = new_start;
            this.end = new_end;
        }
    }
}
