namespace OrderHandlerLibrary
{
    public class Order
    {
        private State _state = null;
        public List<string> history { get; }
        internal uint orderCode { get; }
        internal string orderName { get; }
        internal string clientName { get; }
        internal string shippingAddress { get; }
        internal decimal price { get;  }

        public Order(string clientName, string shippingAddress, 
            string orderName, uint orderCode, decimal price)
        {
            history = new List<string>();

            this.orderName = orderName;
            this.clientName = clientName;
            this.shippingAddress = shippingAddress;
            this.orderCode = orderCode;
            this.price = price;

            this.TransitionTo(new AcceptedState());
            this._state.SetOrder(this);
        }

        internal void TransitionTo(State state)
        {
            string str = $"{DateTime.Now.ToString()}: Transition to {state.GetType().Name}.";
            this.UpdateHistory(str);
            this._state = state;
            this._state.SetOrder(this);
        }

        public void Handle()
        {
            this._state.Handle();
        }

        public void Cancel()
        {
            this._state.Cancel();
        }

        internal void UpdateHistory(string str)
        {
            history.Add(str);
        }

        internal void ClearHistory()
        {
            history.Clear();
        }

        public void RestoreTo(State state)
        {
            string str = $"{DateTime.Now.ToString()}: Order has been restored";
            this.UpdateHistory(str);
            this.TransitionTo(state);
            this._state.SetOrder(this);
        }

    }
}