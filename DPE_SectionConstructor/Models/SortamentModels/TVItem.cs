using DPE_SectionConstructor.Service;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace DPE_SectionConstructor.Models
{
    /// <summary>
    /// Инкапсулирует информацию для TreeViewItem для TreeView
    /// </summary>
    public class TVItem : INotifyPropertyChanged
    {
        private static object _selectedItem = null;
        /// <summary>
        /// Содержит выбранный пользователем элемент
        /// </summary>
        public static object SelectedItem
        {
            get { return _selectedItem; }
            private set
            {
                if (_selectedItem != value)
                {
                    _selectedItem = value;
                    OnSelectedItemChanged();
                }                
            }
        }

        public static event PropertyChangedEventHandler SelectedItemChanged;
        /// <summary>
        /// Происходит при изменении SelectedItem
        /// </summary>
        static void OnSelectedItemChanged([CallerMemberName]string prop = "")
        {
            if (SelectedItemChanged != null)
                SelectedItemChanged (TVItem.SelectedItem, new PropertyChangedEventArgs(prop));
        }

        private bool _isSelected;
        /// <summary>
        /// Отслеживает изменение свойства IsSelected
        /// </summary>
        public bool IsSelected
        {
            get { return _isSelected; }
            set
            {
                if (_isSelected != value)
                {
                    _isSelected = value;
                    if (_isSelected)
                    {
                        SelectedItem = this;
                    }
                }
            }
        }

        public string Name { get; set; }
        public string ParentName { get; set; }
        public ObservableCollection<TVItem> TVItems { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName]string prop = "")
        {           
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }
    }
}
