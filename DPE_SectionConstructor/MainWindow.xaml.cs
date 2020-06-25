using OxyPlot;
using OxyPlot.Series;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace DPE_SectionConstructor
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            DataContext = new AppViewModel();

            //Oxy.Model.MouseDown += Model_MouseDown;

        }

        //private void Model_MouseDown(object sender, OxyMouseDownEventArgs e)
        //{
        //    double X = (sender as LineSeries).InverseTransform(e.Position).X;
        //    double Y = (sender as LineSeries).InverseTransform(e.Position).Y;
        //}

        //TODO: Выбор точки размещения обьекта по нажатию кнопки мыши


    }
}
