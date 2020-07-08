using DPE_SectionConstructor.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DPE_SectionConstructor.Models
{
    public class AngleBeam : Section
    {
        public AngleBeam()
        {
            Name = "Уголок";
            this.GetSectionData();
        }

        public override void GetSectionData()
        {
            double R = r;
            double X0 = 50; //Расстояние от края сечения до OY
            double Y0 = 50; //Расстояние от края сечения до OX


            PtsList = new List<OxyPlot.DataPoint>()
            {
                //                           X               Y
                new OxyPlot.DataPoint(  -X0     ,  h-Y0      ),
                new OxyPlot.DataPoint(  -X0+s-r ,  h-Y0      ),
                new OxyPlot.DataPoint(  -X0+s-r ,  h-Y0-r    ),
                new OxyPlot.DataPoint(  -X0+s   ,  h-Y0-r    ),
                new OxyPlot.DataPoint(  -X0+s   ,  -Y0+s+r   ),
                                                          
                new OxyPlot.DataPoint(  -X0+s+r ,  -Y0+s+r   ),
                new OxyPlot.DataPoint(  -X0+s+r ,  -Y0+s     ),
                new OxyPlot.DataPoint(  b-X0-r  ,  -Y0+s     ),
                new OxyPlot.DataPoint(  b-X0-r  ,  -Y0+s-r   ),
                new OxyPlot.DataPoint(  b-X0    ,  -Y0+s-r   ),
                                                          
                new OxyPlot.DataPoint(  b-X0    ,  -Y0       ),
                new OxyPlot.DataPoint(  -X0+r   ,  -Y0       ),
                new OxyPlot.DataPoint(  -X0+r   ,  -Y0+r     ),
                new OxyPlot.DataPoint(  -X0     ,  -Y0+r     )
            };

            Actions = new List<string>
            {
                "Line",
                "Arc0",
                "Line",
                "Arc180",
                "Line",

                "Arc0",
                "Line",
                "Line",
                "Arc180",
                "Line",

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
            return new AngleBeam() { h = this.h, b = this.b, s = this.s, t = this.t, r = this.r, d = this.d, smX = this.smX, smY = this.smY, Angle = this.Angle };
        }
    }
}
