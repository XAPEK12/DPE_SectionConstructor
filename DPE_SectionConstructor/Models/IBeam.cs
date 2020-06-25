using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
            return new IBeam (){ h = this.h, b = this.b, s = this.s, t = this.t, r = this.r, d = this.d, smX = this.smX, smY = this.smY, Angle = this.Angle };
        }


    }
}
