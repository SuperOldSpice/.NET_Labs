using System;
using System.Collections.Generic;
using PizzaBuilderLibrary;
namespace System
{

    class Program
    {
        static void Main(string[] args)
        {   
            var director = new Director();
            var classicalBuilder = new OpenPizzaBuilder();
            director.Builder = classicalBuilder;

            Console.WriteLine("Creation of margarita:");
            director.BuildMargarita();
            Console.WriteLine(classicalBuilder.GetProduct().ListParts());

            Console.WriteLine("Creation of Pepperoni:");
            director.BuildPepperoni();
            Console.WriteLine(classicalBuilder.GetProduct().ListParts());

            Console.WriteLine("Creation of Calcone Mushroom pizza (calcone is closed type of pizza):");
            var calconeBuilder = new ClosedPizzaBuilder();
            director.Builder = calconeBuilder;
            director.BuildMushrooms();
            Console.WriteLine(calconeBuilder.GetProduct().ListParts());

            Console.WriteLine("Creation of custom calcone pizza:");
            calconeBuilder.AddPizzaBase();
            calconeBuilder.AddTomatoSause();
            calconeBuilder.AddSausages();
            calconeBuilder.AddMushrooms();
            Console.WriteLine(calconeBuilder.GetProduct().ListParts()); 
        }
    }
}