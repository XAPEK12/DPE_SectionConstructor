using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DPE_SectionConstructor.Service
{
    //TODO:Здесь должны быть уравнения строймеха
    public static class StructMech
    {
        public static double CalculateRectI(double b, double h)
        {
            return b * h * h * h / 12;
        }
        public static double CalculateRectI(double a)
        {
            return a * a * a * a / 12;
        }

        public static double CalculateCircleI(double D)
        {
            return Math.PI * D * D * D * D / 64;
        }

        public static double CalculateRectW (double b,double h)
        {
            return b * h * h / 6;
        }

        public static double CalculateRectW(double a)
        {
            return a * a * a / 6;
        }

        public static double CalculateCircleW(double D)
        {
            return Math.PI * D * D * D / 32;
        }

        public static double CalculateRingI(double D, double d)
        {
            return Math.PI * D * D * D * D / 64 * (1 - Math.Pow(d / D, 4));
        }
    }
}
