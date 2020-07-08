using DPE_SectionConstructor.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DPE_SectionConstructor.Models
{
    public class TBeam : Section
    {
        public TBeam()
        {
            Name = "Тавр";
            this.GetSectionData();
        }

        public override void GetSectionData()
        {
            double R = r;
            double Y0 = 50; //Расстояние от края сечения до OX


            PtsList = new List<OxyPlot.DataPoint>()
            {
                //                           X               Y
                new OxyPlot.DataPoint(  -b/2    ,   Y0-t+r  ),
                new OxyPlot.DataPoint(  -b/2    ,   Y0      ),
                new OxyPlot.DataPoint(  b/2     ,   Y0      ),
                new OxyPlot.DataPoint(  b/2     ,   Y0-t+r  ),
                new OxyPlot.DataPoint(  b/2-r   ,   Y0-t+r  ),

                new OxyPlot.DataPoint(  b/2-r   ,   Y0-t    ),
                new OxyPlot.DataPoint(  s/2+r   ,   Y0-t    ),
                new OxyPlot.DataPoint(  s/2+r   ,   Y0-t-r  ),
                new OxyPlot.DataPoint(  s/2     ,   Y0-t-r  ),
                new OxyPlot.DataPoint(  s/2     ,   -h+Y0   ),

                new OxyPlot.DataPoint(  -s/2    ,   -h+Y0   ),
                new OxyPlot.DataPoint(  -s/2    ,   Y0-t-r  ),
                new OxyPlot.DataPoint(  -s/2-r  ,   Y0-t-r  ),
                new OxyPlot.DataPoint(  -s/2-r  ,   Y0-t    ),
                new OxyPlot.DataPoint(  -b/2+r  ,   Y0-t    ),

                new OxyPlot.DataPoint(  -b/2+r  ,   Y0-t+r  )
            };

            Actions = new List<string>
            {
                "Line",
                "Line",
                "Line",
                "Arc270",
                "Line",
                
                "Arc90",
                "Line",
                "Line",
                "Line",
                "Arc0",
                
                "Line",
                "Arc180"
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
            return new TBeam() { h = this.h, b = this.b, s = this.s, t = this.t, r = this.r, R = this.R, d = this.d, smX = this.smX, smY = this.smY, Angle = this.Angle };
        }
    }
}
