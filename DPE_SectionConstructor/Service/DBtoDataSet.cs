using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.OleDb;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DPE_SectionConstructor.Service
{
    public static class DBtoDataSet
    {
        static string connectionString = ConfigurationManager.ConnectionStrings
            ["DPE_SectionConstructor.Properties.Settings.SteelSortamentConnectionString"]
            .ConnectionString;

        static DataSet DataSet { get; set; }

        static DBtoDataSet()
        {
            var sql = "SELECT * FROM Sortament";
            var connection = new OleDbConnection(connectionString);//подключаемся к БД
            try
            {
                connection.Open();//Откраваем БД
                var adapter = new OleDbDataAdapter(sql, connection); //Создать запрос
                DataSet = new DataSet();
                adapter.Fill(DataSet, "Sortament");
            }
            catch (OleDbException ex)
            {
                throw new Exception(ex.ToString());
            }
            finally
            {
                connection.Close();
            }
        }

        public static DataSet GetDataSet ()
        {
            return DataSet.Copy();
        }

    }
}
