using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DPE_SectionConstructor.Service
{
    public static class RowParser
    {
        public static double Parse(DataRow row, string columnName)
        {
            if (row.Table.Columns.Contains(columnName))
                return Double.Parse((string)row[columnName]);
            else 
                return 0;
        }
    }
}
