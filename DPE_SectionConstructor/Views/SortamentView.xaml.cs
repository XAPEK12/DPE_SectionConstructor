using DPE_SectionConstructor.ViewModels;
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
using System.Windows.Shapes;

namespace DPE_SectionConstructor.Views
{
    /// <summary>
    /// Логика взаимодействия для SortamentView.xaml
    /// </summary>
    public partial class SortamentView : Window
    {
        public SortamentView()
        {

            InitializeComponent();
            DataContext = new SortamentViewModel();
        }
    }
}
