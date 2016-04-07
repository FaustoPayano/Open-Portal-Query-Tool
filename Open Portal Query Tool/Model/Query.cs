using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Open_Portal_Query_Tool.Model {
    class Query {
        public bool BalancesGreaterThanZeroOnly { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        private string _block { get; set; }
        private string _lot { get; set; }
        private decimal balance { get; set; }
        public string DebugSelectQuery { get; set; }
        public string DebugWhereQuery { get; set; }
    }
}
