using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DPE_SectionConstructor.Model
{
    public class RectPipe : Section
    {
        public RectPipe()
        {
            Name = "Прямоугольная труба";
            this.GetSectionData();
        }

        public override void GetSectionData()
        {
            double R = r;
            if (h >= b && s >= b / 2) s = b / 2 - r;
            else if (h < b && s >= h / 2) s = h / 2 - r;
            else if (s < 0) s = 0;

            if (h >= b && r >= b / 2) r = b / 2 - s;
            else if (h < b && r >= h / 2) r = h / 2 - s;
            else if (r < 0) r = 0;

            if (h >= b && R > b / 2) R = b / 2;
            else if (h < b && R > h / 2) R = h / 2;
            else if (R < 0) R = 0;

            PtsList = new List<OxyPlot.DataPoint>()
            {
                //                           X               Y
                new OxyPlot.DataPoint(      -b/2+R  ,       h/2),
                new OxyPlot.DataPoint(      b/2-R   ,       h/2),
                    new OxyPlot.DataPoint(  b/2-R   ,       h/2-R),
                new OxyPlot.DataPoint(      b/2     ,       h/2-R),
                new OxyPlot.DataPoint(      b/2     ,       -h/2+R),

                    new OxyPlot.DataPoint(  b/2-R   ,       -h/2+R),
                new OxyPlot.DataPoint(      b/2-R   ,       -h/2),
                new OxyPlot.DataPoint(      -b/2+R  ,       -h/2),
                    new OxyPlot.DataPoint(  -b/2+R  ,       -h/2+R),
                new OxyPlot.DataPoint(      -b/2    ,       -h/2+R),

                new OxyPlot.DataPoint(      -b/2    ,       h/2-R),
                    new OxyPlot.DataPoint(  -b/2+R  ,       h/2-R),

                new OxyPlot.DataPoint(      -b/2+R  ,       h/2),

                new OxyPlot.DataPoint(      -b/2+s+r,       h/2-s),
                new OxyPlot.DataPoint(      b/2-s-r ,       h/2-s),
                    new OxyPlot.DataPoint(  b/2-s-r ,       h/2-s-r),

                new OxyPlot.DataPoint(      b/2-s   ,       h/2-s-r),
                new OxyPlot.DataPoint(      b/2-s   ,       -h/2+s+r),
                    new OxyPlot.DataPoint(  b/2-s-r ,       -h/2+s+r),
                new OxyPlot.DataPoint(      b/2-s-r ,       -h/2+s),
                new OxyPlot.DataPoint(      -b/2+s+r,       -h/2+s),

                    new OxyPlot.DataPoint(  -b/2+s+r,       -h/2+s+r),
                new OxyPlot.DataPoint(      -b/2+s  ,       -h/2+s+r),
                new OxyPlot.DataPoint(      -b/2+s  ,       h/2-s-r),
                    new OxyPlot.DataPoint(  -b/2+s+r,       h/2-s-r),

                    new OxyPlot.DataPoint(  -b/2+s+r,       h/2-s)
            };

            Actions = new List<string>
            {
                "Line",
                "Arc0",
                "Line",
                "Arc270",
                "Line",

                "Arc180",
                "Line",
                "Arc90",
                "",
                "Line",

                "Arc0",
                "Line",
                "Arc270",
                "Line",
                "Arc180",

                "Line",
                "Arc90"

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
            return new RectPipe() { h = this.h, b = this.b, s = this.s, t = this.t, r = this.r, R = this.R, d = this.d, smX = this.smX, smY = this.smY, Angle = this.Angle };
        }
    }
}
