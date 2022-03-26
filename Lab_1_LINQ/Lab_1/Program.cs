using System;
using Bank;
using System.Linq;
using System.Collections.Generic;

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
            Console.WriteLine("Hello World!");
            Currency one = (Currency)1;
    
        }
    }
}
