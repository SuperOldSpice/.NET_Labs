namespace PizzaBuilderLibrary
{
    public class Director
    {
        private IBuilder _builder;

        public IBuilder Builder
        {
            set { _builder = value; }
        }

        public void BuildMargarita()
        {
            this._builder.AddPizzaBase();
            this._builder.AddTomatoSause();
            this._builder.AddOlives();
            this._builder.AddTomatoes();
            this._builder.AddCheese();
        }

        public void BuildPepperoni()
        {
            this._builder.AddPizzaBase();
            this._builder.AddTomatoSause();
            this._builder.AddSausages();
            this._builder.AddOlives();
            this._builder.AddCheese();
        }

        public void BuildMushrooms()
        {
            this._builder.AddPizzaBase();
            this._builder.AddCreamSause();
            this._builder.AddMushrooms();
            this._builder.AddOlives();
            this._builder.AddCheese();
        }
    }
}