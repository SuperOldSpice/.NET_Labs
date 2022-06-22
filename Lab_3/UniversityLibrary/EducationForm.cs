using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UniversityLibrary
{
    public abstract class EducationForm
    {
        internal decimal score { get; private set; }
        internal decimal contractPrice { get; }
        internal abstract bool CheckPayment();
        internal void Pay(decimal price)
        {
            if(score >= price) score -= price;
        }

        internal void DepositFunds(decimal sum)
        {
            score += sum;
        }
        public EducationForm(decimal score, decimal contractPrice)
        {
            this.score = score;
            this.contractPrice = contractPrice;
        }
    }
}
