
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Net.Http.Headers;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Shapes;

namespace DPE_SectionConstructor.Model
{
   
    /// <summary>
    /// Это базовый класс для всех сечений.
    /// Содержит необходимые поля и методы для работы с сечениями.
    /// Все сечения должны наследовать этот класс.
    /// </summary>
    public class Section : Service.Base, ICloneable
    {       

        #region Section fields

        /// <summary>
        /// Содержит исходный лист точек для отрисовки сечения.
        /// Центр сечения совпадает с началом координат (0,0).
        /// Для отрисовки окружности необходимо обозначить точку ее центра.
        /// Все точки записываются по порядку против часовой стрелки.
        /// </summary>
        protected List<OxyPlot.DataPoint> PtsList; 
        /// <summary>
        /// Базовая точка сечения. Всегда находится в его центре.
        /// </summary>
        protected OxyPlot.DataPoint BasePoint { get; set; } = new OxyPlot.DataPoint(0, 0);
        /// <summary>
        /// Содержит лист цействий для отрисвоки:
        /// "Line" - линия. Содержит 2 точки - начало и конец.
        /// "Arc0" - четверть окружности(дуга 90 градусов).
        /// Содержит 3 точки - начало, центр и конец.
        /// Расположена в 1 координатной четверти.
        /// Число "0" после "Arc" - угол поворота окружности. 
        /// </summary>
        protected List<string> Actions;
        /// <summary>
        /// Группирует данные в удобную для методов форму  
        /// </summary>
        protected OxyPlot.DataPoint[][] DataMass { get; set; }
        
        #endregion

       
        #region Section methods

        /// <summary>
        /// Двигает точку на плоскости
        /// </summary>
        public OxyPlot.DataPoint MovePoint(OxyPlot.DataPoint point, double X, double Y)
        {
            return new OxyPlot.DataPoint(point.X + X, point.Y + Y);
        }

        /// <summary>
        /// Вращает точку на плоскости
        /// </summary>
        /// <param name="point">Вращаемая точка</param>
        /// <param name="basePoint">Центр вращения</param>
        /// <param name="angle">Угол вращения в градусах</param>
        public OxyPlot.DataPoint RotatePoint(OxyPlot.DataPoint point, OxyPlot.DataPoint basePoint, double angle)
        {
            angle = angle * Math.PI / 180;
            return new OxyPlot.DataPoint((point.X - basePoint.X) * Math.Cos(angle) - (point.Y - basePoint.Y) * Math.Sin(angle) + basePoint.X,
                                         (point.X - basePoint.X) * Math.Sin(angle) + (point.Y - basePoint.Y) * Math.Cos(angle) + basePoint.Y); 
        }

        /// <summary>
        /// Формирует DataMass для следующих методов: GetLineSeriesList, GetFunctionSeriesList.
        /// </summary>
        protected void GetDataMass()
        {


            DataMass = new OxyPlot.DataPoint[PtsList.Count][];
            string action;
            for (int i = 0, j = 0; i < Actions.Count; i++, j++)
            {
                action = Actions[i].ToUpper();
                if (action.Contains("ARC")) action = "ARC";
                switch (action)
                {
                    case "LINE":
                        DataMass[i] = new OxyPlot.DataPoint[2];
                        if (j != PtsList.Count - 1)
                        {
                            DataMass[i][0] = PtsList[j];
                            DataMass[i][1] = PtsList[j + 1];
                        }
                        else
                        {
                            DataMass[i][0] = PtsList[j];
                            DataMass[i][1] = PtsList[0];
                        }
                        break;

                    case "ARC":
                        DataMass[i] = new OxyPlot.DataPoint[3];
                        if (j != PtsList.Count - 2)
                        {
                            DataMass[i][0] = PtsList[j];
                            DataMass[i][1] = PtsList[j + 1];
                            DataMass[i][2] = PtsList[j + 2];
                        }
                        else
                        {
                            DataMass[i][0] = PtsList[j];
                            DataMass[i][1] = PtsList[j + 1];
                            DataMass[i][2] = PtsList[0];
                        }
                        j++;
                        break;

                    default:
                        break;
                }
            }
        }

        /// <summary>
        /// Отрисовывает линии.
        /// GetDataMass() должен быть объявлен ранее.
        /// </summary>
        /// <param name="color">Цвет линий</param>
        /// <returns></returns>
        public List<OxyPlot.Series.LineSeries> GetLineSeriesList(OxyPlot.OxyColor color)
        {
            
            var LineSeriesList = new List<OxyPlot.Series.LineSeries>();
            for (int i = 0; i < Actions.Count; i++)
            {                
                switch (Actions[i].ToUpper())
                {
                    case "LINE":
                        LineSeriesList.Add(new OxyPlot.Series.LineSeries { Color = color, ItemsSource = DataMass[i] });
                        break;

                    default:
                        break;
                }
            }
            return LineSeriesList;
        }

        /// <summary>
        /// Отрисовывает скругления.
        /// GetDataMass() должен быть объявлен ранее.
        /// </summary>
        /// <param name="color">Цвет скруглений</param>
        public List<OxyPlot.Series.FunctionSeries> GetFunctionSeriesList(OxyPlot.OxyColor color)
        {
            
            double deg;
            double angle;            
            var FunctionSeriesList = new List<OxyPlot.Series.FunctionSeries>();
            var S = new OxyPlot.Series.FunctionSeries();            
            double r = 0;
            Func<double, double> func;
            OxyPlot.Series.FunctionSeries F;

            for (int i = 0; i < Actions.Count; i++)
            {
                if (DataMass[i] != null && Actions[i].ToUpper().Contains("ARC"))
                {
                    Double.TryParse(Regex.Replace(Actions[i], @"[^\d]+", ""), out deg);
                    r = Math.Sqrt(Math.Pow(DataMass[i][1].X - DataMass[i][0].X, 2) + Math.Pow(DataMass[i][1].Y - DataMass[i][0].Y, 2)); //Вычисляем радиус
                    func = (x) => DataMass[i][1].Y + Math.Sqrt(Math.Pow(r, 2) - Math.Pow(x - DataMass[i][1].X, 2)); //Формула дуги
                    F = new OxyPlot.Series.FunctionSeries(func, DataMass[i][1].X, Math.Abs(r) + DataMass[i][1].X, 0.001) { Color = color };
                    angle = Angle + deg;

                    for (int j = 0; j < F.Points.Count; j++) 
                        F.Points[j] = RotatePoint(F.Points[j], DataMass[i][1], angle);

                    FunctionSeriesList.Add(F);
                }
            }

            return FunctionSeriesList;
        }

        /// <summary>
        /// Отрисовывает модель для для следующих методов: GetLineSeriesList, GetFunctionSeriesList.
        /// Должен быть объявлен перед ними.
        /// GetDataMass() должен быть объявлен в конце.
        /// </summary>
        public virtual void GetSectionData() 
        { throw new NotImplementedException(); }//TODO: Поставить заглушки

        public void DrawSection(OxyPlot.PlotModel model, OxyPlot.OxyColor color )
        {
            GetFunctionSeriesList(color)?.ForEach(model.Series.Add);
            GetLineSeriesList(color)?.ForEach(model.Series.Add);
        }

        public virtual object Clone()
        {
            return null;
        }

        public virtual void Calculate() { }

        #endregion
    }
}
