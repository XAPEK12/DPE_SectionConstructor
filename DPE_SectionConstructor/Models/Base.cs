using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace DPE_SectionConstructor.Service
{
    /// <summary>
    /// Это базовый класс для Model и ViewModel.
    /// Содержит базовые свойства для Model и ViewModel.
    /// Реализует INotifyPropertyChanged для MVVM.
    /// </summary>
    public class Base : INotifyPropertyChanged
    {
        #region Section fields

        protected string _Name; // Имя сечения

        protected double _h; //Высота сечения
        protected double _b; //Ширина сечения
        protected double _s; //Толщина стенки
        protected double _t; //Толщина полки
        protected double _r; //Радиус перехода стенки в полку
        protected double _d; //Диаметр

        protected double _P; //Масса одного метра погонного
        protected double _A; //Площадь
        protected double _Ix; //Момент иннерции по Х
        protected double _Iy; //Момент иннерции по Y
        protected double _Wx; //Момент сопротивления по Х
        protected double _Wy; //Момент сопротивления по Y
        protected double _Sx; //Статический момент по Х
        protected double _Sy; //Статический момент по Y
        protected double _ix; //Радиус иннерции по Х
        protected double _iy; //Радиус иннерции по Y
        protected double _It; //Момент иннерции при кручении

        protected double _smX;//Смещение по X
        protected double _smY;//Смещение по Y
        protected double _Angle;//Угол поворота в градусах
        #endregion
        #region Section properties

        public string Name
        {
            get { return _Name; }
            protected set { _Name = value; OnPropertyChanged("Name"); }
        }

        /// <summary>
        /// Высота сечения
        /// </summary>
        public double h
        {
            get { return _h; }
            set { _h = value; OnPropertyChanged("h"); }
        }
        /// <summary>
        /// Ширина сечения
        /// </summary>
        public double b
        {
            get { return _b; }
            set { _b = value; OnPropertyChanged("b"); }
        }
        /// <summary>
        /// Толщина стенки
        /// </summary>
        public double s
        {
            get { return _s; }
            set { _s = value; OnPropertyChanged("s"); }
        }
        /// <summary>
        /// Толщина полки
        /// </summary>
        public double t
        {
            get { return _t; }
            set { _t = value; OnPropertyChanged("t"); }
        }
        /// <summary>
        /// Радиус перехода стенки в полку
        /// </summary>
        public double r
        {
            get { return _r; }
            set { _r = value; OnPropertyChanged("r"); }
        }
        /// <summary>
        /// Диаметр
        /// </summary>
        public double d
        {
            get { return _d; }
            set { _d = value; OnPropertyChanged("d"); }
        }

        /// <summary>
        /// Масса одного метра погонного
        /// </summary>
        public double P
        {
            get { return _P; }
            set { _P = value; OnPropertyChanged("P"); }
        }
        /// <summary>
        /// Площадь сечения
        /// </summary>
        public double A
        {
            get { return _A; }
            set { _A = value; OnPropertyChanged("A"); }
        }
        /// <summary>
        /// Момент иннерции по Х
        /// </summary>
        public double Ix
        {
            get { return _Ix; }
            set { _Ix = value; OnPropertyChanged("Ix"); }
        }
        /// <summary>
        /// Момент иннерции по Y
        /// </summary>
        public double Iy
        {
            get { return _Iy; }
            set { _Iy = value; OnPropertyChanged("Iy"); }
        }
        /// <summary>
        /// Момент сопротивления по Х
        /// </summary>
        public double Wx
        {
            get { return _Wx; }
            set { _Wx = value; OnPropertyChanged("Wx"); }
        }
        /// <summary>
        /// Момент сопротивления по Y
        /// </summary>
        public double Wy
        {
            get { return _Wy; }
            set { _Wy = value; OnPropertyChanged("Wy"); }
        }
        /// <summary>
        /// Статический момент по X
        /// </summary>
        public double Sx
        {
            get { return _Sx; }
            set { _Sx = value; OnPropertyChanged("Sx"); }
        }
        /// <summary>
        /// Статический момент по Y
        /// </summary>
        public double Sy
        {
            get { return _Sy; }
            set { _Sy = value; OnPropertyChanged("Sy"); }
        }
        /// <summary>
        /// Радиус иннерции по Х
        /// </summary>
        public double ix
        {
            get { return _ix; }
            set { _ix = value; OnPropertyChanged("ix"); }
        }
        /// <summary>
        /// Радиус иннерции по Х
        /// </summary>
        public double iy
        {
            get { return _iy; }
            set { _iy = value; OnPropertyChanged("iy"); }
        }
        /// <summary>
        /// Радиус иннерции при кручении
        /// </summary>
        public double It
        {
            get { return _It; }
            set { _It = value; OnPropertyChanged("It"); }
        }

        /// <summary>
        /// Смещение по Х от (0,0)
        /// </summary>
        public double smX
        {
            get { return _smX; }
            set { _smX = value; OnPropertyChanged("smX"); }
        }
        /// <summary>
        /// Смещение по Y от (0,0)
        /// </summary>
        public double smY
        {
            get { return _smY; }
            set { _smY = value; OnPropertyChanged("smY"); }
        }
        /// <summary>
        /// Угол поворота в градусах.
        /// </summary>
        public double Angle
        {
            get { return _Angle; }
            set { _Angle = value; OnPropertyChanged("Angle"); }
        }
        #endregion

        public OxyPlot.OxyColor RedColor = OxyPlot.OxyColor.FromRgb(255, 0, 0);
        public OxyPlot.OxyColor BlackColor = OxyPlot.OxyColor.FromRgb(0, 0, 0);

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName]string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }
    }
}
