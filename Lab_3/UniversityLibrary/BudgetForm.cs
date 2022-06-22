using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UniversityLibrary
{
    public class BudgetForm : EducationForm
    {
        public BudgetForm(decimal score, decimal contractPrice) : base(score, contractPrice) { }
        internal override bool CheckPayment()
        {
            return true;
        }
    }
}
