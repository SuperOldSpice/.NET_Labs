using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UniversityLibrary
{
    abstract public class Degree
    {
        internal DateTime startDate { get; }
        internal DateTime endDate { get; }
        internal string group { get; }
        internal uint semester { get; private protected set; }
        public Degree(DateTime startDate, string group, uint semester)
        {
            this.startDate = startDate;
            this.group = group;
            this.semester = semester;
        }

        internal virtual uint FinishSession()
        {
            semester += 1;
            return semester;
        }
    }
}
