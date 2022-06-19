using System;
using Bank;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using System.Xml.Linq;
using System.Xml;

namespace MyApp 
{
    internal class Program
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
        
        static XDocument CreateClientsXML(List<Client> clients)
        {
            XDocument xdoc = new XDocument();
            XElement people = new XElement("clients");

            foreach (Client client in clients)
            {
                XElement newClient = new XElement("client");
                XAttribute newClientNameAttribute = new XAttribute("name", client.name);
                XElement newClientCode = new XElement("code", client.code);
                XElement newClientIPN = new XElement("IPN", client.IPN);
                XElement newClientEmail = new XElement("email", client.email);

                newClient.Add(newClientNameAttribute);
                newClient.Add(newClientCode);
                newClient.Add(newClientIPN);
                newClient.Add(newClientEmail);

                people.Add(newClient);
            }

            xdoc.Add(people);
            return xdoc;
        }

        static void createCreditsXML(List<Credit> credits)
        {

            XmlWriterSettings settings = new XmlWriterSettings();
            settings.Indent = true;
            using (XmlWriter writer = XmlWriter.Create("credits.xml", settings))
            {
                writer.WriteStartElement("credits");
                foreach (Credit credit in credits)
                {
                    writer.WriteStartElement("credit");
                    writer.WriteElementString("creditCode", credit.code.ToString());
                    writer.WriteElementString("clientCode", credit.client_code.ToString());
                    writer.WriteElementString("creditBankAccount", credit.bank_account.ToString());
                    writer.WriteElementString("creditCurrency", credit.currency.ToString());
                    writer.WriteElementString("creditSum", credit.sum.ToString());
                    writer.WriteElementString("creditPercent", credit.percent.ToString());
                    writer.WriteElementString("creditStart", credit.start.ToString());
                    writer.WriteElementString("creditEnd", credit.end.ToString());
                    writer.WriteEndElement();
                }
                writer.WriteEndElement();
            }
        }

        static void createDepositsXML(List<Deposit> deposits)
        {

            XmlWriterSettings settings = new XmlWriterSettings();
            settings.Indent = true;
            using (XmlWriter writer = XmlWriter.Create("deposits.xml", settings))
            {
                writer.WriteStartElement("deposits");
                foreach (Deposit deposit in deposits)
                {
                    writer.WriteStartElement("deposit");
                    writer.WriteElementString("depositCode", deposit.code.ToString());
                    writer.WriteElementString("clientCode", deposit.client_code.ToString());
                    writer.WriteElementString("depositBankAccount", deposit.bank_account.ToString());
                    writer.WriteElementString("depositCurrency", deposit.currency.ToString());
                    writer.WriteElementString("depositSum", deposit.sum.ToString());
                    writer.WriteElementString("depositPercent", deposit.percent.ToString());
                    writer.WriteElementString("depositStart", deposit.start.ToString());
                    writer.WriteElementString("depositEnd", deposit.end.ToString());
                    writer.WriteEndElement();
                }
                writer.WriteEndElement();
            }
        }

        static void Main(string[] args)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Work with XML \n");

            XDocument clientsXML = CreateClientsXML(clients);
            clientsXML.Save("clients.xml");

            createCreditsXML(credits);
            XDocument creditsXML = XDocument.Load("credits.xml");

            createDepositsXML(deposits);
            XDocument depositsXML = XDocument.Load("deposits.xml");

            
            var q1 = clientsXML.Element("clients")?
                .Elements("client")
                .Select(p => new
                {
                    name = p.Attribute("name")?.Value,
                    code = p.Element("code")?.Value,
                    email = p.Element("email")?.Value
                });

            foreach (var client in q1)
                Console.WriteLine(client);


            var q2 = creditsXML.Element("credits")?
                .Elements("credit")
                .Select(p => new
                {
                    code = p.Attribute("creditCode")?.Value,
                    clientCode = p.Element("clientCode")?.Value,
                    bankAccount = p.Element("creditBankAccount")?.Value,
                    sum = p.Element("creditSum")?.Value,
                    percent = p.Element("creditPercent")?.Value,
                    start = p.Element("creditStart")?.Value,
                    end = p.Element("creditEnd")?.Value,
                    currency = p.Element("creditCurrency")?.Value
                });

            Console.WriteLine();
            foreach (var credit in q2)
                Console.WriteLine(credit);


            var q3 = depositsXML.Element("deposits")?
                .Elements("deposit");

            Console.WriteLine();
            foreach (var deposit in q3)
                Console.WriteLine(deposit);


            var q4 = clientsXML.Element("clients")?   
                        .Elements("client")             
                        .FirstOrDefault(p => p.Attribute("name")?.Value == "Homer Winfield");

            Console.WriteLine();
            Console.WriteLine(q4);


            var q5 = from credit in creditsXML.Element("credits").Elements("credit")
                     where credit.Element("creditCurrency").Value is "UAH"
                     orderby credit.Element("creditSum").Value
                     select credit.Element("creditSum").Value;

            Console.WriteLine();
            foreach (var sum in q5)
                Console.WriteLine(sum);

            var q6 = depositsXML.Element("deposits")?
                .Elements("deposit")? 
                .Where((deposit) =>
                {
                    return Convert.ToInt32(deposit.Element("depositSum")?.Value) > 200; 
                }).OrderByDescending(deposit => deposit.Element("depositCurrency")?.Value)
                  .ThenByDescending(deposit => Convert.ToInt32(deposit.Element("depositSum")?.Value));

            Console.WriteLine();
            foreach (var deposit in q6) Console.WriteLine($"Currency: {deposit.Element("depositCurrency")?.Value}  Value: {deposit.Element("depositSum").Value}");

            var q7 = depositsXML.Element("deposits")
                .Elements("deposit")?
                .SkipWhile(deposit => Convert.ToInt32(deposit.Element("depositSum")?.Value) < 2000)
                .TakeWhile(deposit => Convert.ToInt32(deposit.Element("depositSum")?.Value) <= 40000);

            Console.WriteLine();
            foreach (var deposit in q7)
                Console.WriteLine(deposit.Element("depositSum")?.Value);

            var q8 = from client in clientsXML
                            .Element("clients")?
                            .Elements("client")
                     join deposit in depositsXML
                            .Element("deposits")
                            .Elements("deposit") 
                     on client.Element("code")?.Value equals deposit.Element("clientCode")?.Value
                     select new 
                     { 
                         name = client.Attribute("name").Value,
                         sum = deposit.Element("depositSum").Value 
                     };
            Console.WriteLine();
            foreach (var x in q8)
                Console.WriteLine(x.name + " deposit sum: " + x.sum);

            var q9 = depositsXML.Element("deposits")?
                        .Elements("deposit")
                        .Sum(n =>
                        {
                            if (n.Element("clientCode").Value == "7234" && 
                                n.Element("depositCurrency").Value == "UAH")
                            {
                                return int.Parse(n.Element("depositSum").Value);
                            } else
                            {
                                return 0;
                            }
                        });


            Console.WriteLine();
            Console.WriteLine($" Clients with code 7234 deposits in UAH sum is {q9} ");


            var q10 = from client in q1
                      join credit in q2 on
                      client.code equals credit.clientCode
                      select new
                      { name = client.name,
                        sum = credit.sum,
                        currency = credit.currency
                      };

            Console.WriteLine();
            foreach (var i in q10){
                Console.WriteLine(i);
            }

            var q11 = from client in q10
                      group client by client.name;
                    

            Console.WriteLine();
            foreach (var group in q11)
            {
                Console.WriteLine(group.Key);
                foreach (var client in group)
                Console.WriteLine(client);
            }

            var q12 = from mygroup in q11
                      select new
                      {
                          name = mygroup.Key,
                          sumUSD = mygroup
                                    .Where(x => x.currency == "USD")
                                    .Sum(x => Convert.ToInt32(x.sum)),
                          sumUAH = mygroup
                                    .Where(x => x.currency == "UAH")
                                    .Sum(x => Convert.ToInt32(x.sum))
                      };

            Console.WriteLine();
            foreach (var i in q12)
            {
                Console.WriteLine(i);
            }

            var q13 = q3.Select(deposit => new
            {
                clientCode = deposit.Element("clientCode").Value,
                sum = Convert.ToInt32(deposit.Element("depositSum").Value),
                currency = deposit.Element("depositCurrency").Value
            });

            Console.WriteLine();
            foreach (var i in q13)
            {
                Console.WriteLine(i);
            }

            var q14 = from client in q1
                      join deposit in q13 on
                      client.code equals deposit.clientCode
                      select new
                      {
                          name = client.name,
                          sum = deposit.sum,
                          currency = deposit.currency
                      };

            Console.WriteLine();
            foreach (var i in q14)
            {
                Console.WriteLine(i);
            }

            var q15 = from client in q14
                      group client by client.name into mygroup
                      select new
                      {
                          name = mygroup.Key,
                          sumUSD = mygroup
                                    .Where(x => x.currency == "USD")
                                    .Sum(x => Convert.ToInt32(x.sum)),
                          sumUAH = mygroup
                                    .Where(x => x.currency == "UAH")
                                    .Sum(x => Convert.ToInt32(x.sum))
                      };

            Console.WriteLine();
            foreach (var i in q15)
            {
                Console.WriteLine(i);
            }
        }
    }
}