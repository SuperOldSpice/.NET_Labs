using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaBuilderLibrary
{
    public class Pizza
    {
        private List<object> _parts = new List<object>();

        private double _price = 0;

        public void Add(string part)
        {
            this._parts.Add(part);
        }

        public void IncreasePrice(double price)
        {
            this._price += price;
        }

        public double GetPrice(double price)
        {
            return this._price;
        }

        public string ListParts()
        {
            string str = string.Empty;

            for (int i = 0; i < this._parts.Count; i++)
            {
                str += this._parts[i] + ", ";
            }

            str = str.Remove(str.Length - 2); 

            return "Price: " + _price + " Pizza consists of: " + str + "\n";
        }
    }
}
