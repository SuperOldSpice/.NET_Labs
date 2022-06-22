using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UniversityLibrary
{
    public class ContractForm : EducationForm
    {
        public ContractForm(decimal score, decimal contractPrice) : base(score, contractPrice) { }

        internal override bool CheckPayment()
        {
            if (this.score >= this.contractPrice)
            {
                this.Pay(this.contractPrice);
                return true;
            }
            else
            {
                return false;
            }
            
        }
    }
}
