using System;
using OrderHandlerLibrary;
namespace Lab_5
{
    class Program
    {
        static void Main()
        {
            Console.WriteLine("Simple Order");
            var order = new Order(clientName: "Mark Tyson", shippingAddress: "Kyiv, Akademika 48",
            orderName: "Pc mouse HyperX", orderCode: 234234, price: Convert.ToDecimal(12.45));
            order.Handle();
            order.Handle();
            order.Handle();
            order.Handle();
            order.Handle();
            order.Handle();

            PrintHistory(order.history);
            order = null;

            Console.WriteLine("Order with restore");
            order = new Order(clientName: "Johnny Depp", shippingAddress: "Kyiv, Solomianska 13",
            orderName: "Keyboard Logitech", orderCode: 126523, price: Convert.ToDecimal(19.21));
            order.Handle();
            order.Handle();
            order.Cancel();
            order.RestoreTo(new PaidState());
            order.Handle();
            order.Handle();
            order.Handle();

            PrintHistory(order.history);
        }

        static void PrintHistory(List<string> history)
        {
            Console.WriteLine("Order history:");
            foreach (string line in history)
            { 
                Console.WriteLine(line);
            }
            Console.WriteLine();
        }
    }


}