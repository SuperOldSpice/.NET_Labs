using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaBuilderLibrary
{
    public interface IBuilder
    {
        void AddPizzaBase();

        void AddMushrooms();

        void AddTomatoes();

        void AddOlives();

        void AddCheese();

        void AddSausages();

        void AddTomatoSause();

        void AddCreamSause();
    }
}
