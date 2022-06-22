using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderHandlerLibrary
{
    public class AcceptedDeliveryState : State
    {
        internal override void Handle()
        {
            string str = $"{DateTime.Now.ToString()}: Delievered to {_order.shippingAddress}";
            this._order.UpdateHistory(str);
            this._order.TransitionTo(new DeliveredState());
        }

        internal override void Cancel()
        {
            this._order.TransitionTo(new CanceledState());
        }
    }
}
