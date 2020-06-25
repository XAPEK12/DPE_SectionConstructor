using DPE_SectionConstructor.Service;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace DPE_SectionConstructor.Models
{
    public class DataGridModel
    {

        public DataSet SortamentDS { get; }
        public string TableName { get; } = "DataGrid";
        List<string> ColumnTitlesList;
        public Dictionary<string, string> PropsDictionary = new Dictionary<string, string>
        {
            {"Марка",   "Marka" },
            {"P, кг|м", "P" },
            {"d, см",   "B" },
            {"h, см",   "H" },
            {"b, см",   "B" },
            {"s, см",   "Ts" },
            {"t, см",   "Tf" },
            {"r, см",   "R" },
            {"A, см",   "A" },
            {"Ix, см4", "Ix" },
            {"Wx, см3", "Wx" },
            {"Sx, см3", "Sx" },
            {"ix, см",  "I0x" },
            {"Iy, см4", "Iy"  },
            {"Wy, см3", "Wy"  },
            {"Sy, см3", "Sy"  },
            {"iy, см",  "I0y" },
            {"It, см4", "It" }
        };

        public DataGridModel(string type)
        {
            var Types = new SortamentTypes().Types;

            if (Types.Contains(type))
            {

                SortamentDS = DBtoDataSet.GetDataSet();
                var dataTable = SortamentDS.Tables[0].Clone();
                dataTable.TableName = "PermTable";
                SortamentDS.Tables.Add(dataTable);

                foreach (DataRow row in SortamentDS.Tables[0].Select(String.Format("TypeName = '{0}'", type)))
                    SortamentDS.Tables[1].ImportRow(row);

                SortamentDS.Tables.Add(TableName);
                SortamentDS.Tables[TableName].Columns.Add("№", typeof(int));
                SortamentDS.Tables[TableName].PrimaryKey = new DataColumn[] { SortamentDS.Tables[TableName].Columns["№"] };
                SortamentDS.Tables[TableName].Columns["№"].AutoIncrement = true;
                SortamentDS.Tables[TableName].Columns["№"].AutoIncrementSeed = 1;
                ColumnTitlesList = PropsDictionary.Keys.ToList();
                var i = Array.IndexOf(Types, type);
                if (i == 0)
                {   
                    ColumnTitlesList.Remove("d, см");
                    ColumnTitlesList.Remove("h, см");
                    ColumnTitlesList.Remove("t, см");
                }
                else if (i == 1)
                {
                    ColumnTitlesList.Remove("d, см");
                    ColumnTitlesList.Remove("t, см");
                }
                else if (i >= 2 && i <= 19)
                {
                    ColumnTitlesList.Remove("d, см");
                }
                else if (i > 19 && i <= 22)
                {
                    ColumnTitlesList.Remove("h, см");
                    ColumnTitlesList.Remove("b, см");
                    ColumnTitlesList.Remove("r, см");
                    ColumnTitlesList.Remove("t, см");
                }
                else if (i > 22 && i <= 25)
                {
                    ColumnTitlesList.Remove("h, см");
                    ColumnTitlesList.Remove("d, см");
                    ColumnTitlesList.Remove("t, см");
                }
                else
                {
                    ColumnTitlesList.Remove("d, см");
                    ColumnTitlesList.Remove("t, см");
                }                             

                foreach (string title in ColumnTitlesList)
                {
                    SortamentDS.Tables[TableName].Columns.Add(new DataColumn(title,typeof(string)));
                }

                foreach (DataRow row in SortamentDS.Tables[1].Rows)
                {
                    var newRow = SortamentDS.Tables[TableName].NewRow();
                    foreach (DataColumn col in SortamentDS.Tables[TableName].Columns)
                    {
                        string value;
                        if (PropsDictionary.TryGetValue(col.ColumnName, out value))
                        {
                            newRow[col.ColumnName] = row[value];
                        }
                    }
                    SortamentDS.Tables[TableName].Rows.Add(newRow);
                }
            }

        }
               

    }
}
