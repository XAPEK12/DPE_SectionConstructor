using DPE_SectionConstructor.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DPE_SectionConstructor.Models
{
    public class CProfile : Section
    {
        public CProfile()
        {
            Name = "Гнутый С-образный профиль";
            this.GetSectionData();
        }

        public override void GetSectionData()
        {
            double R = r;
            double X0 = 50; //Расстояние от края сечения до OY


            PtsList = new List<OxyPlot.DataPoint>()
            {
                //                           X               Y
                new OxyPlot.DataPoint(   b-X0       ,  h/2-d    ),
                new OxyPlot.DataPoint(   b-X0       ,  h/2-r    ),
                new OxyPlot.DataPoint(   b-X0-r     ,  h/2-r    ),
                new OxyPlot.DataPoint(   b-X0-r     ,  h/2      ),
                new OxyPlot.DataPoint(   -X0+r      ,  h/2      ),
                                              
                new OxyPlot.DataPoint(   -X0+r      ,  h/2-r    ),
                new OxyPlot.DataPoint(   -X0        ,  h/2-r    ),
                new OxyPlot.DataPoint(   -X0        ,  -h/2+r   ),
                new OxyPlot.DataPoint(   -X0+r      ,  -h/2+r   ),
                new OxyPlot.DataPoint(   -X0+r      ,  -h/2     ),
                                              
                new OxyPlot.DataPoint(   b-X0-r     , -h/2      ),
                new OxyPlot.DataPoint(   b-X0-r     , -h/2+r    ),
                new OxyPlot.DataPoint(   b-X0       , -h/2+r    ),
                new OxyPlot.DataPoint(   b-X0       , -h/2+d    ),
                new OxyPlot.DataPoint(   b-X0-s     , -h/2+d    ),
                                              
                new OxyPlot.DataPoint(   b-X0-s     , -h/2+s+r  ),
                new OxyPlot.DataPoint(   b-X0-s-r   , -h/2+s+r  ),
                new OxyPlot.DataPoint(   b-X0-s-r   , -h/2+s    ),
                new OxyPlot.DataPoint(   -X0+s+r    , -h/2+s    ),
                new OxyPlot.DataPoint(   -X0+s+r    , -h/2+s+r  ),
                                              
                new OxyPlot.DataPoint(   -X0+s      , -h/2+s+r  ),
                new OxyPlot.DataPoint(   -X0+s      , h/2-r-s   ),
                new OxyPlot.DataPoint(   -X0+s+r    , h/2-r-s   ),
                new OxyPlot.DataPoint(   -X0+s+r    , h/2-s     ),
                new OxyPlot.DataPoint(   b-X0-s-r   , h/2-s     ),
                                              
                new OxyPlot.DataPoint(   b-X0-s-r   , h/2-s-r   ),
                new OxyPlot.DataPoint(   b-X0-s     , h/2-s-r   ),
                new OxyPlot.DataPoint(   b-X0-s     , h/2-d     ),
                
            };

            Actions = new List<string>
            {
                "Line",                
                "Arc0",
                "Line",
                "Arc90",
                "Line",

                "Arc180",
                "Line",
                "Arc270",
                "Line",
                "Line",

                "Line",
                "Arc270",
                "Line",
                "Arc180",
                "Line",
                "Arc90",
                "Line",
                "Arc0",
                "Line",
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
            return new CProfile() { h = this.h, b = this.b, s = this.s, t = this.t, r = this.r, R = this.R, d = this.d, smX = this.smX, smY = this.smY, Angle = this.Angle };
        }
    }
}
