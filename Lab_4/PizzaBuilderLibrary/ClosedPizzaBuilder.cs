using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaBuilderLibrary
{
    public class ClosedPizzaBuilder : IBuilder
    {
        private Pizza _product = new Pizza();

        public ClosedPizzaBuilder()
        {
            this.Reset();
        }

        public void Reset()
        {
            this._product = new Pizza();
        }

        public void AddPizzaBase()
        {
            this._product.Add("ClosedPizzaBase");
            this._product.IncreasePrice(6.8);
        }

        public void AddMushrooms()
        {
            this._product.Add("Mushrooms");
            this._product.IncreasePrice(1.2);
        }

        public void AddTomatoes()
        {
            this._product.Add("Tomatoes");
            this._product.IncreasePrice(0.5);
        }

        public void AddOlives()
        {
            this._product.Add("Olives");
            this._product.IncreasePrice(1.5);
        }

        public void AddCheese()
        {
            this._product.Add("Cheese");
            this._product.IncreasePrice(2.1);
        }

        public void AddSausages()
        {
            this._product.Add("Sausages");
            this._product.IncreasePrice(2.4);
        }

        public void AddTomatoSause()
        {
            this._product.Add("TomatoSause");
            this._product.IncreasePrice(0.3);
        }

        public void AddCreamSause()
        {
            this._product.Add("CreamSause");
            this._product.IncreasePrice(0.4);
        }

            public Pizza GetProduct()
        {
            Pizza result = this._product;

            this.Reset();

            return result;
        }
    }
}
