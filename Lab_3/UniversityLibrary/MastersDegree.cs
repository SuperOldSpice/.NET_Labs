using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UniversityLibrary
{
    public class MastersDegree : Degree
    {
        public MastersDegree(DateTime startDate, string group, 
            uint semester) : base(startDate, group, semester) { }
    }
}
