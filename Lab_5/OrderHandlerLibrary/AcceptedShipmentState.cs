using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderHandlerLibrary
{
    public class AcceptedShipmentState : State
    {
        internal override void Handle()
        {
            this._order.TransitionTo(new AcceptedDeliveryState());
        }

        internal override void Cancel()
        {
            this._order.TransitionTo(new CanceledState());
        }
    }
}
