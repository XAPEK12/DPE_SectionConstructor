using DPE_SectionConstructor.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DPE_SectionConstructor.Models
{
    class ZProfile:Section
    {
        public ZProfile()
        {
            Name = "Гнутый Z-образный профиль";
            this.GetSectionData();
        }

        public override void GetSectionData()
        {
            double R = r;


            PtsList = new List<OxyPlot.DataPoint>()
            {
                //                           X               Y
                new OxyPlot.DataPoint(  b-s/2   , h/2-s     ),
                new OxyPlot.DataPoint(  b-s/2   , h/2       ),
                new OxyPlot.DataPoint(  -s/2+r  , h/2       ),
                new OxyPlot.DataPoint(  -s/2+r  , h/2-r     ),
                new OxyPlot.DataPoint(  -s/2    , h/2-r     ),

                new OxyPlot.DataPoint(  -s/2    , -h/2+s+r  ),
                new OxyPlot.DataPoint(  -s/2-r  , -h/2+s+r  ),
                new OxyPlot.DataPoint(  -s/2-r  , -h/2+s    ),
                new OxyPlot.DataPoint(  -b+s/2  , -h/2+s    ),
                new OxyPlot.DataPoint(  -b+s/2  , -h/2      ),

                new OxyPlot.DataPoint(  s/2-r   , -h/2      ),
                new OxyPlot.DataPoint(  s/2-r   , -h/2+r    ),
                new OxyPlot.DataPoint(  s/2     , -h/2+r    ),
                new OxyPlot.DataPoint(  s/2     , h/2-s-r   ),
                new OxyPlot.DataPoint(  s/2+r   , h/2-s-r   ),

                new OxyPlot.DataPoint(  s/2+r , h/2-s  )
            };

            Actions = new List<string>
            {
                "Line",
                "Line",
                "Arc90",
                "Line",
                "Arc270",
                "Line",
                "Line",
                "Line",
                "Arc270",
                "Line",
                "Arc90",
                "Line"
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
            return new ZProfile() { h = this.h, b = this.b, s = this.s, t = this.t, r = this.r, R = this.R, d = this.d, smX = this.smX, smY = this.smY, Angle = this.Angle };
        }

    }
}
