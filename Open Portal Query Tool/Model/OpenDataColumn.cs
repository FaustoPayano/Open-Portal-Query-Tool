using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace Open_Portal_Query_Tool.Model {
    public class OpenDataColumn {
        private string _columnName { get; set; }
        private string _visualName { get; set; }


        /// <summary>
        /// Constructor for OpenDataColumn, first parameter is the column name, second parameter is how the column will appear in Drawer content.
        /// </summary>
        /// <param name="columnName"></param>
        /// <param name="visualName"></param>
        public OpenDataColumn(string columnName, string visualName) {
            _columnName = columnName;
            _visualName = visualName;
        }

       
        public override string ToString() {
            return _visualName;
        }
    }
}
