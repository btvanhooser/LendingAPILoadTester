using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LendingAPILoadTester.Utilities
{
    public class ApplicationModel
    {
        public int id { get; set; }
        public string firstname { get; set; }
        public string lastname { get; set; }
        public int ssn { get; set; }
        public string employer { get; set; }
        public int income { get; set; }
        public string incomeFrequency { get; set; }
        public int requestedAmount { get; set; }
        public int requestedTerm { get; set; }
        public string phoneNumber { get; set; }
        public string emailAddress { get; set; }
        public string isBranchEmployee { get; set; }
        public int employeeID { get; set; }
        public string lendercode { get; set; }
        public string status { get; set; }
    }
}
