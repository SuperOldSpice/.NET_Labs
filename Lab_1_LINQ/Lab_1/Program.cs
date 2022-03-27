using System;
using Bank;
using System.Linq;
using System.Collections.Generic;
using System.Text;

namespace Lab_1
{
    class Program
    {
        static List<Client> clients = new List<Client>()
        { 
            new Client("Mark Tyson", 7234, 12334, "mark@gmail.com"),
            new Client("Mike Talib", 1234, 13334, "mike@gmail.com"),
            new Client("Jessica Tyson", 9274, 10334, "jess@gmail.com"),
            new Client("Erik Cartman", 2264, 11334, "erik@gmail.com"),
            new Client("Lisa Simpson", 8454, 12335, "liss@gmail.com"),
            new Client("Homer Winfield", 2334, 12184, "hommy@gmail.com")
        };

        static List<Credit> credits = new List<Credit>()
        {
            new Credit(43131, 7234, 23234, Currency.USD, 3000, 8, new DateTime(2018, 7, 24), new DateTime(2019, 7, 24)),
            new Credit(42431, 1234, 54244, Currency.USD, 1500, 5, new DateTime(2018, 7, 22), new DateTime(2019, 7, 2)),
            new Credit(43143, 9274, 12334, Currency.USD, 2500, 3, new DateTime(2019, 7, 24), new DateTime(2021, 7, 24)),
            new Credit(12131, 2264, 32134, Currency.UAH, 25000, 5, new DateTime(2018, 8, 24), new DateTime(2019, 9, 9)),
            new Credit(42131, 9274, 52134, Currency.UAH, 40000, 2, new DateTime(2018, 12, 24), new DateTime(2021, 7, 24)),
            new Credit(41451, 7234, 54334, Currency.UAH, 8000, 4, new DateTime(2018, 11, 21), new DateTime(2020, 8, 21)),
        };

        static List<Deposit> deposits = new List<Deposit>()
        {
            new Deposit(43251, 7234, 23234, Currency.USD, 6000, 2, new DateTime(2019, 7, 24), new DateTime(2021, 7, 24)),
            new Deposit(12431, 1234, 54244, Currency.USD, 2000, 3, new DateTime(2018, 7, 22), new DateTime(2019, 7, 2)),
            new Deposit(54143, 8454, 32134, Currency.USD, 800, 2, new DateTime(2019, 7, 24), new DateTime(2021, 7, 24)),
            new Deposit(23131, 2264, 32134, Currency.UAH, 25000, 5, new DateTime(2018, 8, 24), new DateTime(2019, 9, 9)),
            new Deposit(15131, 7234, 23234, Currency.UAH, 65000, 10, new DateTime(2016, 12, 24), new DateTime(2022, 7, 24)),
            new Deposit(32451, 7234, 23234, Currency.UAH, 9000, 8, new DateTime(2019, 11, 21), new DateTime(2023, 8, 21)),
        };
        static void Main(string[] args)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Simple LINQ \n");

            Console.WriteLine("Clients:");
            var q1 = from client in clients
                     select client.name;
            foreach (var client in q1)
                Console.WriteLine(client);

            Console.WriteLine("\nNew in LINQ:");
            var q2 = from client in clients
                     select new { name = "Mark", age = 18};
            foreach (var client in q2)
            {
                Console.WriteLine(client);
                break;
            }

            Console.WriteLine("\nClients with code > 5000:");
            var q3 = from client in clients
                     where client.code > 5000
                     select client.name;
            foreach (var client in q3)
                Console.WriteLine(client);

            Console.WriteLine("\nSorting:");
            var q4 = from client in clients
                     where client.code > 1000
                     orderby client.code
                     select client.code;
            foreach (var code in q4)
                Console.WriteLine(code);

            Console.WriteLine("\nCredits sum of credits in UAH:");
            var q5 = from credit in credits
                     where credit.currency is Currency.UAH
                     orderby credit.sum
                     select credit.sum;
            foreach (var sum in q5)
                Console.WriteLine(sum);

            Console.WriteLine("\nSorting with expanding methods:");
            var q6 = deposits.Where((deposit) =>
            {
                return deposit.sum > 200 && deposit.currency == Currency.USD;
            }).OrderByDescending(deposit => deposit.sum).ThenByDescending(deposit => deposit.client_code);
            foreach (var deposit in q6) Console.WriteLine(deposit.sum);

            Console.WriteLine("\nSkipWhile and TakeWhile");
            int[] intArray = new int[] { 1, 2, 3, 4, 5, 6, 7, 8 };
            var q7 = intArray.SkipWhile(x => (x < 3)).TakeWhile(x => x <= 5);
            foreach (var x in q7)
                Console.WriteLine(x);

            Console.WriteLine("\nINNER JOIN");
            var q8 = from client in clients
                     join deposit in deposits on client.code equals deposit.client_code
                     select new { name = client.name, sum = deposit.sum };
            foreach (var x in q8)
                Console.WriteLine(x.name + " deposit sum: " + x.sum);

            Console.WriteLine("\nJOIN with WHERE");
            var q9 = from client in clients
                     from deposit in deposits
                     where client.code == deposit.client_code
                     select new { name = client.name, sum = deposit.sum };
            foreach (var x in q9)
                Console.WriteLine(x.name + " deposit sum: " + x.sum);

            Console.WriteLine("\nGroup Join");
            var q10 = from client in clients
                     join deposit in deposits on client.code equals deposit.client_code into temp
                     select new { name = client.name, depositGroup = temp };
            foreach (var client in q10)
            {
                Console.WriteLine(client.name);
                foreach (var deposit in client.depositGroup)
                    Console.WriteLine("   " + deposit.sum);
            }

            Console.WriteLine("\nCross Join and Group Join");
            var q11 = from client in clients
                      join deposit in deposits on client.code equals deposit.client_code into temp
                      from t in temp
                      select new { name = client.name, sum = t.sum, cnt = temp.Count() };
            foreach (var x in q11)
                Console.WriteLine(x);

            Console.WriteLine("\nOuter Join");
            var q12 = from client in clients
                      join deposit in deposits on client.code equals deposit.client_code into temp
                      from t in temp.DefaultIfEmpty()
                      select new { name = client.name, sum = ((t == null) ? 0 : t.sum) };
            foreach (var x in q12)
                Console.WriteLine(x);

            Console.WriteLine("\nGrouping by currency");
            var q13 = from credit in credits 
                      group credit by credit.currency into g
                      select new { Key = g.Key, Values = g};
            foreach (var credit in q13)
            {
                Console.WriteLine(credit.Key);
                foreach (var s in credit.Values)
                    Console.WriteLine(" " + s.sum);
            }

            Console.WriteLine("\nGrouping with aggregation functions ");
            var q14 = from credit in credits
                      group credit by credit.client_code into g
                      select new { Key = g.Key, Values = g, cnt = g.Count(), cnt1 = g.Count(credit => credit.sum > 500), sum = g.Sum(credit => credit.sum), min = g.Min(credit => credit.sum) };
            foreach (var credit in q14)
            {
                Console.WriteLine("Client code: " + credit.Key + " Number: "  + credit.cnt + " Sum: " + credit.sum + " Min: " + credit.min);
                foreach (var y in credit.Values)
                    Console.WriteLine(" " + y.sum);
            }

            Console.WriteLine("\nCredit sums of clients whose name starts with 'M' showed by their e-mails");
            var q15 = from client in clients
                      join credit in credits on client.code equals credit.client_code into temp
                      where client.name.StartsWith("M")
                      select new { name = client.name, email= client.email, Values = temp};
            foreach (var client in q15)
            {
                Console.WriteLine("email: " + client.email);
                foreach (var y in client.Values)
                    Console.WriteLine("Sum: " + y.sum + " Currency type: " + y.currency);

            }

        }

    }
}
