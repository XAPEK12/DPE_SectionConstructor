using System;
using System.Windows.Media.Converters;

namespace DPE_SectionConstructor.Service
{
    public static class StructMech
    {
        /// <summary>
        /// Координата центра тяжести
        /// </summary>
        /// <param name="S">Статический момент</param>
        /// <param name="A">Площадь</param>
        /// <returns></returns>
        public static double GravityCenter(double S, double A)
        {
            return S / A;
        }

        /// <summary>
        /// Статический момент иннерции
        /// </summary>
        /// <param name="A">Площадь</param>
        /// <param name="a">Расстояние до оси</param>
        /// <returns></returns>
        public static double CalculateS(double A, double a)
        {
            return A * a;
        }

        /// <summary>
        /// Площадь прямоугольника
        /// </summary>
        /// <param name="h">Высота</param>
        /// <param name="b">Ширина</param>
        /// <returns></returns>
        public static double RectangleA(double h, double b)
        {
            return b * h;
        }

        /// <summary>
        /// Площадь квадрата
        /// </summary>
        /// <param name="a">Сторона квадрата</param>
        /// <returns></returns>
        public static double RectangleA(double a)
        {
            return Math.Pow(a, 2);
        }

        /// <summary>
        /// Площадь круга
        /// </summary>
        /// <param name="r">Радиус</param>
        /// <returns></returns>
        public static double CircleA(double r)
        {
            return Math.PI * Math.Pow(r, 2);
        }

        /// <summary>
        /// Момент иннерции прямоугольника.
        /// b*h^3/12
        /// </summary>
        /// <param name="h">Васота</param>
        /// <param name="b">Ширина</param>
        /// <returns></returns>
        public static double RectangleI(double h, double b)
        {
            return b * Math.Pow(h, 3) / 12;
        }

        /// <summary>
        /// Момент иннерции квадрата
        /// a^4/12
        /// </summary>
        /// <param name="a">сторона квадрата</param>
        /// <returns></returns>
        public static double RectangleI(double a)
        {
            return Math.Pow(a, 4) / 12;
        }

        /// <summary>
        /// Момент иннерции круга.
        /// pi*d^4/64
        /// </summary>
        /// <param name="d">Диаметр</param>
        /// <returns></returns>
        public static double CircleI(double d)
        {
            return Math.PI * Math.Pow(d, 4) / 64;
        }

        /// <summary>
        /// Момент иннерции относительно оси
        /// </summary>
        /// <param name="I">Момент иннерции относительно центральной оси</param>
        /// <param name="A">Площпдь сечения</param>
        /// <param name="a">Расстояние между осью и центром тяжести</param>
        /// <returns></returns>
        public static double MoveI(double I, double A, double a)
        {
            return I + Math.Pow(a, 2) * A;
        }

        /// <summary>
        /// Радиус иннерции
        /// </summary>
        /// <param name="I">Момент иннерции</param>
        /// <param name="A">Площадь</param>
        /// <returns></returns>
        public static double Calculatei(double I, double A)
        {
            return Math.Sqrt(I / A);
        }

        /// <summary>
        /// Момент сопротивления
        /// </summary>
        /// <param name="I">Момент иннерции</param>
        /// <param name="a">Расстояние до самой удаленной точки</param>
        /// <returns></returns>
        public static double CalculateW(double I, double a)
        {
            return I / a;
        }


    }
}
