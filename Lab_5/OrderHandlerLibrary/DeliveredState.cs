using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderHandlerLibrary
{
    public class DeliveredState : State
    {
        internal override void Handle()
        {
            string str = $"{DateTime.Now.ToString()}: {_order.clientName} has " +
                $"received {_order.orderName}";
            this._order.UpdateHistory(str);
            this._order.TransitionTo(new ReceivedState());
        }

        internal override void Cancel()
        {
            this._order.TransitionTo(new CanceledState());
        }
    }
}
