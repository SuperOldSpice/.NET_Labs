using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderHandlerLibrary
{
    public abstract class State
    {
        protected Order _order;
        public void SetOrder(Order order)
        {
            this._order = order;
        }
        internal abstract void Handle();

        internal abstract void Cancel();

    }
}
