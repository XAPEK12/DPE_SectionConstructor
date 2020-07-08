using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Converters;
using static DPE_SectionConstructor.Service.StructMech;

namespace DPE_SectionConstructor.Model
{
    public class IBeam : Section
    {
        public IBeam()
        {            
            Name = "Двутавр";
            this.GetSectionData();
        }


        public override void GetSectionData()
        {
            if (r > t) r = t;
            double R = r;
            PtsList = new List<OxyPlot.DataPoint>()
            {
                //                           X               Y
                new OxyPlot.DataPoint( -b/2       ,   h / 2 + r - t   ),
                new OxyPlot.DataPoint( -b/2       ,   h / 2            ),
                new OxyPlot.DataPoint(  b/2       ,   h / 2            ),
                new OxyPlot.DataPoint(  b/2       ,   h / 2 + r - t   ),
                    new OxyPlot.DataPoint(  b/2-r     ,   h / 2 + r - t   ),
                new OxyPlot.DataPoint(  b/2 - r   ,   h / 2 - t       ),

                new OxyPlot.DataPoint(  s/2 + R   ,   h / 2 - t       ),
                    new OxyPlot.DataPoint(  s / 2 + R ,   h / 2 - R - t   ),
                new OxyPlot.DataPoint(  s / 2     ,   h / 2 - t - R   ),
                new OxyPlot.DataPoint(  s / 2     ,  -h / 2 + t + R   ),
                    new OxyPlot.DataPoint(  s / 2 + R ,  -h / 2 + R + t   ),
                new OxyPlot.DataPoint(  s/2 + R   ,  -h / 2 + t       ),
                new OxyPlot.DataPoint(  b/2 - r   ,  -h / 2 + t       ),
                    new OxyPlot.DataPoint(  b / 2 - r ,  -h / 2 - r + t   ),

                new OxyPlot.DataPoint(  b/2       ,  -h / 2 - r + t   ),
                new OxyPlot.DataPoint(  b/2       ,  -h / 2            ),
                new OxyPlot.DataPoint( -b/2       ,  -h / 2            ),
                new OxyPlot.DataPoint( -b/2       ,  -h / 2 - r + t   ),
                    new OxyPlot.DataPoint(  -b / 2 + r ,  -h / 2 - r + t   ),
                new OxyPlot.DataPoint( -b/2 + r   ,  -h / 2 + t       ),

                new OxyPlot.DataPoint( -s/2 - R   ,  -h / 2 + t       ),
                    new OxyPlot.DataPoint(  -s/2 - R ,  -h / 2 + R + t   ),
                new OxyPlot.DataPoint( -s / 2     ,  -h / 2 + t + R   ),
                new OxyPlot.DataPoint( -s / 2     ,   h / 2 - t - R   ),
                    new OxyPlot.DataPoint(  -s/2 - R ,  h / 2 - R - t   ),
                new OxyPlot.DataPoint(-s/2 - R    ,   h / 2 - t       ),
                new OxyPlot.DataPoint(-b/2 + r    ,   h / 2 - t       ),
                    new OxyPlot.DataPoint(  -b/2 + r ,  h / 2 + r - t   ),
            };

            Actions = new List<string>()
            {
                "line",
                "line",
                "line",
                "Arc270",
                "line",

                "Arc90",
                "line",
                "Arc180",
                "line",
                "Arc0",

                "line",
                "line",
                "line",
                "Arc90",
                "line",

                "Arc270",
                "line",
                "Arc0",
                "line",
                "Arc180",
            };

            BasePoint = MovePoint(BasePoint, smX, smY);
            for (int i = 0; i < PtsList.Count; i++)
            {
                PtsList[i] = MovePoint(PtsList[i], smX, smY);
                PtsList[i] = RotatePoint(PtsList[i], BasePoint, Angle);
            }
            GetDataMass();
        }


        public override object Clone()
        {            
            return new IBeam (){ h = this.h, b = this.b, s = this.s, t = this.t, r = this.r,  R= this.R, d = this.d, smX = this.smX, smY = this.smY, Angle = this.Angle };
        }

        public override void Calculate()
        {
            
            A = h * b - 2 * ((h - 2 * t) * (b / 2 - s / 2)) - 4 * (r * r - Math.PI * r * r / 4) + 4 * (r * r - Math.PI * r * r / 4);

            double A1 = RectangleA(h - 2 * t, s);
            double Ix1 = RectangleI(h - 2 * t, s);
            double Iy1 = RectangleI(s, h - 2 * t);

            double A2 = RectangleA(r, b - 2 * r);
            double Ix2 = RectangleI(b - 2 * r, r);
            double Iy2 = RectangleI(r, b - 2 * r);

            double A3 = RectangleA(t - r, b);
            double Ix3 = RectangleI(t - r, b);
            double Iy3 = RectangleI(b, t - r);

            double A4 = CircleA(r) / 4;
            double I4 = CircleI(2 * r) / 4;

            double A5 = RectangleA(r) - CircleA(r) / 4;
            double I5 = MoveI(RectangleI(r), RectangleA(r), r / 2) - CircleI(r) / 4;

            Ix = Ix1 + 2 * MoveI(Ix2, A2, h / 2 - t + r / 2)
                    + 2 * MoveI(Ix3, A3, h / 2 - (t - r) / 2)
                    + 4 * MoveI(I4, A4, h / 2 - t + r)
                    + 4 * MoveI(I5, A5, h / 2 - t - r);

            Iy = Iy1 + Iy2 + Iy3
                    + 4 * MoveI(I4, A4, b - r)
                    + 4 * MoveI(I5, A5, s + r);

            ix = Calculatei(Ix, A);
            iy = Calculatei(Iy, A);
            Wx = CalculateW(Ix , h/2);
            Wy = CalculateW(Iy , b/2);
        }       
    }
    
}
