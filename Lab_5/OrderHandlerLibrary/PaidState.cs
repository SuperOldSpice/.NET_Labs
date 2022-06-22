using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderHandlerLibrary
{
    public class PaidState : State
    {
        internal override void Handle()
        {
            string str = $"{DateTime.Now.ToString()}: Received ${_order.price}";
            this._order.UpdateHistory(str);
            this._order.TransitionTo(new AcceptedShipmentState());
        }

        internal override void Cancel()
        {
            this._order.TransitionTo(new CanceledState());
        }
    }
}
