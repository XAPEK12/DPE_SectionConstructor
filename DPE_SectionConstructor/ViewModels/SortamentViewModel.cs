using DPE_SectionConstructor.Models;
using DPE_SectionConstructor.Service;
using OxyPlot.Axes;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Configuration;
using System.Data;
using System.Data.OleDb;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DPE_SectionConstructor.ViewModels
{
    


    public class SortamentViewModel : Base
    {
        private DataSet dataSet;
        TVItem SelectedItem;

        private DataView _DataGridItemSource;
        public DataView DataGridItemSource
        {
            get { return _DataGridItemSource; }
            set { _DataGridItemSource = value; OnPropertyChanged("DataGridItemSource"); }
        }

        private ObservableCollection<TVItem> _TVItemsSourse;
        public ObservableCollection<TVItem> TVItemsSource 
        {
            get 
            {               
                return _TVItemsSourse;
            }
            set { _TVItemsSourse = value; }
        }
                
        private int _SelectedRow;
        public int SelectedRow
        {
            get { return _SelectedRow; }
            set { _SelectedRow = value; OnPropertyChanged("SelectedRow"); }
        }

        private RelayCommand _SortamentAddCommand;
        public RelayCommand SortamentAddCommand
        {
            get
            {
                return _SortamentAddCommand ??
                  (_SortamentAddCommand = new RelayCommand(obj =>
                  {
                      var newRow = dataSet?.Tables["DataGrid"].NewRow();
                      newRow =  dataSet?.Tables["DataGrid"].Rows.Find(SelectedRow+1);

                      h = RowParser.Parse(newRow, "h, см");
                      b = RowParser.Parse(newRow, "b, см");
                      s = RowParser.Parse(newRow, "s, см");
                      t = RowParser.Parse(newRow, "t, см");
                      r = RowParser.Parse(newRow, "r, см");
                      d = RowParser.Parse(newRow, "d, см");

                      #region Check

                      //TODO:Сделать проверки
                      //if (!newRow.Table.Columns.Contains("h, см"))
                      //    h = RowParser.Parse(newRow, "b, см") * 10; //квадратное сечение


                      #endregion

                      OnPropertyChanged("SortamentAddCommand");                      
                  }));
            }
        }

        private double Parse(DataRow dataRow, object row, string v, object columnName)
        {
            throw new NotImplementedException();
        }

        public SortamentViewModel()
        {
            TVItemsSource = new TVModel().TVItems;
            TVItem.SelectedItemChanged += TVItem_SelectedItemChanged;

        }
         
        private void TVItem_SelectedItemChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            SelectedItem = TVItem.SelectedItem as TVItem;
            dataSet = new DataGridModel(SelectedItem.Name)?.SortamentDS;
            DataGridItemSource = dataSet?.Tables["DataGrid"].DefaultView;
        }
                



       









    }
}
