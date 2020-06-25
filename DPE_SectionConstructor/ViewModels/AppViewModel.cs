using DPE_SectionConstructor.Model;
using DPE_SectionConstructor.Service;
using DPE_SectionConstructor.ViewModels;
using DPE_SectionConstructor.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Globalization;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;

namespace DPE_SectionConstructor
{    

    public class AppViewModel : Base
    {
        SortamentView Sortament;
        //TODO: Посмотреть несколько окон в MVVM
        private RelayCommand _AddFromSortamentCommand;
        public RelayCommand AddFromSortamentCommand
        {
            get 
            {
                return _AddFromSortamentCommand ??
                    (_AddFromSortamentCommand = new RelayCommand(obj =>
                    {
                        Sortament = new SortamentView();
                        (Sortament.DataContext as SortamentViewModel).PropertyChanged += Sortament_PropertyChanged1;
                        Sortament.ShowDialog();
                        Sortament.Activate();
                    }));
            }
        }

        private void Sortament_PropertyChanged1(object sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName == "SortamentAddCommand")
            {
                this.h = (sender as SortamentViewModel).h;
                this.b = (sender as SortamentViewModel).b;
                this.s = (sender as SortamentViewModel).s;
                this.t = (sender as SortamentViewModel).t;
                this.r = (sender as SortamentViewModel).r;
                this.d = (sender as SortamentViewModel).d;

                Sortament.Close();
            }
        }

        private string _CommandString;
        /// <summary>
        /// Командная строка для отладки
        /// </summary>
        public string CommandString
        {
            get { return _CommandString; }
            set { _CommandString = value; OnPropertyChanged("CommandString"); }
        }

        private int _SelectedSectionIndex = 0;
        /// <summary>
        /// Номер выбранного сечения в листе BindingList<Section> Sections
        /// </summary>
        public int SelectedSectionIndex
        {
            get { return _SelectedSectionIndex; }
            set 
            {
                if (value < 0) _SelectedSectionIndex = Sections.Count - 1;
                else if (value > Sections.Count-1) _SelectedSectionIndex = 0;
                else _SelectedSectionIndex = value;
                OnPropertyChanged("SelectedSectionIndex"); 
            }
        }

        private string _SelectedSectionType;
        /// <summary>
        /// Выбранный тип сечения в листе List<string> SectionTypes
        /// </summary>
        public string SelectedSectionType
        {
            get { return _SelectedSectionType; }
            set { _SelectedSectionType = value; OnPropertyChanged("SelectedSectionType"); }
        }

        private Section _SelectedSection;
        /// <summary>
        /// Текущее сечение из  BindingList<Section> Sections
        /// </summary>
        public Section SelectedSection
        {
            get { return _SelectedSection; }
            set { _SelectedSection = value; OnPropertyChanged("SelectedSection"); }
        }
        
        private RelayCommand _AddCommand;
        /// <summary>
        /// Добавляет сечение в лист BindingList<Section> Sections
        /// на нулевую позицию
        /// </summary>
        public RelayCommand AddCommand
        {
            get
            {
                return _AddCommand ??
                  (_AddCommand = new RelayCommand(obj =>
                  {   
                      Section section = (Section)SelectedSection.Clone();
                      Sections.Insert(0, section);                      
                      SelectedSectionIndex = 0;
                      SelectedSection = Sections[0];
                  }));
            }
        }

        private RelayCommand _RemoveCommand;
        /// <summary>
        /// Удаляет текущее сечение из BindingList<Section> Sections
        /// </summary>
        public RelayCommand RemoveCommand
        {
            get
            {
                return _RemoveCommand ??
                    (_RemoveCommand = new RelayCommand(obj =>
                    {
                        Section section = obj as Section;
                        if (section != null)
                        {
                            Sections.Remove(section);
                            SelectedSectionIndex--;
                            SelectedSection = Sections[SelectedSectionIndex];
                        }
                        
                    },
                    (obj) => Sections.Count>1));
            }
        }

        private RelayCommand _NextCommand;
        /// <summary>
        /// Следующее сечение.
        /// Увеличивает SelectedSectionIndex на 1
        /// </summary>
        public RelayCommand NextCommand
        {
            get 
            {
                return _NextCommand ??
                    (_NextCommand = new RelayCommand(obj =>
                    {
                        SelectedSectionIndex++;
                        SelectedSection = Sections[SelectedSectionIndex];

                    }, (obj) => Sections.Count > 1));
            }
        } //TODO: разобраться с сохраненийм свойств сечений при переключении

        private RelayCommand _PrevionsCommand;
        /// <summary>
        /// Предыдущее сечение. Уменьшает SelectedSectionIndex на 1
        /// </summary>
        public RelayCommand PrevionsCommand
        {
            get
            {
                return _PrevionsCommand ??
                    (_PrevionsCommand = new RelayCommand(obj =>
                    {
                        SelectedSectionIndex--;
                        SelectedSection = Sections[SelectedSectionIndex];
                    }, (obj) => Sections.Count > 1));
            }
        }

        /// <summary>
        /// Типы сечений
        /// </summary>
        public List<string> SectionTypes { get; set; }

        /// <summary>
        /// Список сечений
        /// </summary>
        public BindingList<Section> Sections { get; set; }

       
        private OxyPlot.PlotModel _OxyModel;
        public OxyPlot.PlotModel OxyModel
        {
            get 
            {
                _OxyModel = new OxyPlot.PlotModel
                {
                    Title = "",
                    IsLegendVisible = false,
                    Padding = new OxyPlot.OxyThickness(1),
                    DefaultFont = "PT Sans Narrow",
                    LegendBorderThickness = 0,
                    PlotMargins = new OxyPlot.OxyThickness(5),
                    PlotAreaBorderThickness = new OxyPlot.OxyThickness(0),
                    PlotType = OxyPlot.PlotType.Cartesian,
                };
                               
                switch (SelectedSectionType)
                {

                    case "Уголок":
                        //Sections[SelectedSectionIndex] = new AngleBeam();
                        break;

                    case "Швеллер":
                        //Sections[SelectedSectionIndex] = new ChannelBeam();
                        break;

                    case "Двутавр":
                        Sections[SelectedSectionIndex] = new IBeam()
                        {
                            h = this.h,
                            b = this.b,
                            s = this.s,
                            t = this.t,
                            r = this.r,
                            d = this.d,
                            smX = this.smX,
                            smY = this.smY,
                            Angle = this.Angle
                        };
                        break;

                    case "Тавр":
                        //Sections[SelectedSectionIndex] = new TBeam();
                        break;

                    case "Круглая труба":
                        //Sections[SelectedSectionIndex] = new RoundPipe();
                        break;

                    case "Прямоугольная труба":
                        Sections[SelectedSectionIndex] = new RectPipe()
                        {
                            h = this.h,
                            b = this.b,
                            s = this.s,
                            t = this.t,
                            r = this.r,
                            d = this.d,
                            smX = this.smX,
                            smY = this.smY,
                            Angle = this.Angle
                        };
                        break;

                    case "Гнутый С-образный профиль":
                        //Sections[SelectedSectionIndex] = new CProfile();
                        break;

                    case "Гнутый Z-образный профиль":
                        //Sections[SelectedSectionIndex] = new ZProfile();
                        break;

                    default:
                        break;
                }
                
                SelectedSection = Sections[SelectedSectionIndex];

                for (int i = 0; i< Sections.Count;i++)
                {
                    if (i == SelectedSectionIndex)
                    {
                        Sections[i].GetSectionData();
                        Sections[i].GetFunctionSeriesList(RedColor)?.ForEach(_OxyModel.Series.Add);
                        Sections[i].GetLineSeriesList(RedColor)?.ForEach(_OxyModel.Series.Add);
                    }
                    else 
                    {
                        Sections[i].GetFunctionSeriesList(BlackColor)?.ForEach(_OxyModel.Series.Add);
                        Sections[i].GetLineSeriesList(BlackColor)?.ForEach(_OxyModel.Series.Add);
                    }
                }
                
                return _OxyModel; 
            }
                        
        }
       
        public AppViewModel()
        {           

            SectionTypes = new List<string>
            {
                "Уголок",
                "Швеллер",
                "Двутавр",
                "Тавр",
                "Круглая труба",
                "Прямоугольная труба",
                "Гнутый С-образный профиль",
                "Гнутый Z-образный профиль"
            };

            this.h = 50;
            this.b = 25;
            this.s = 1;
            this.t = 2;
            this.r = 1;
            this.d = 90;

            Sections = new BindingList<Section> { new IBeam()
                {
                    h = this.h ,
                    b = this.b ,
                    s = this.s ,
                    t = this.t ,
                    r = this.r ,
                    d = this.d
                }
            };           
            SelectedSectionType = SectionTypes[2];
            SelectedSection = Sections[SelectedSectionIndex];

            var Сult = CultureInfo.GetCultureInfo("ru-RU");
            CultureInfo.CurrentCulture = CultureInfo.GetCultureInfo("en-EN");

            foreach (var ax in OxyModel.Axes)
                ax.Maximum = ax.Minimum = Double.NaN;
            OxyModel.ResetAllAxes();
            this.PropertyChanged += AppViewModel_PropertyChanged;
            OxyModel.MouseDown += OxyModel_MouseDown;

        }

        private void OxyModel_MouseDown(object sender, OxyPlot.OxyMouseDownEventArgs e)
        {
            
        }

        int i = 0;
        private void AppViewModel_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName != "OxyModel" && e.PropertyName != "CommandString"
                && e.PropertyName != "SelectedSection" )
            {                
                CommandString = "Событий: " + i;
                i++;
                OnPropertyChanged("OxyModel");
            }
        }
                      
    }
}

