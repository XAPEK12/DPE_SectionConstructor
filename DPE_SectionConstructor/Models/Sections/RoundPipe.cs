using DPE_SectionConstructor.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DPE_SectionConstructor.Models
{
    class RoundPipe : Section
    {
        public RoundPipe()
        {
            Name = "Круглая труба";
            this.GetSectionData();
        }

        public override void GetSectionData()
        {
            double R = r;


            PtsList = new List<OxyPlot.DataPoint>()
            {
                //                           X               Y
                new OxyPlot.DataPoint(  0  ,  d/2  ),
                new OxyPlot.DataPoint(  0  ,  0  ),
                new OxyPlot.DataPoint(  -d/2  ,  0  ),
                new OxyPlot.DataPoint(  0  ,  0  ),
                new OxyPlot.DataPoint(  0  ,  -d/2  ),

                new OxyPlot.DataPoint(  0  ,  0  ),
                new OxyPlot.DataPoint(  d/2  ,  0  ),
                new OxyPlot.DataPoint(  0  ,  0  ),
                new OxyPlot.DataPoint(  0  ,  d/2  ),
                new OxyPlot.DataPoint(  0  ,  d/2-s  ),

                new OxyPlot.DataPoint(  0  ,  0  ),
                new OxyPlot.DataPoint(  -d/2+s  ,  0  ),
                new OxyPlot.DataPoint(  0  ,  0  ),
                new OxyPlot.DataPoint(  0  ,  -d/2+s  ),
                new OxyPlot.DataPoint(  0  ,  0  ),

                new OxyPlot.DataPoint(  d/2-s  ,  0  ),
                new OxyPlot.DataPoint(  0  ,  0  )
            };

            Actions = new List<string>
            {
                "Arc0",
                "Arc90",
                "Arc180",
                "Arc270",
                "",

                "Arc0",
                "Arc90",
                "Arc180",
                "Arc270",
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
            return new RoundPipe() { h = this.h, b = this.b, s = this.s, t = this.t, r = this.r, d = this.d, smX = this.smX, smY = this.smY, Angle = this.Angle };
        }

    }
}
