using System;
using System.Collections.Generic;
using MathNet.Numerics.LinearAlgebra;
using OxyPlot;
using OxyPlot.Axes;
using OxyPlot.Series;

namespace kNN.ViewModels
{
    public class PercentVideoGameVsIceCreamPerYearScatterPlotModel
    {
        const int FREQ_FLYER = 0;
        const int PERCENT_VID_GAME = 1;
        const int LITER_ICE_CREAM = 2;

        public PercentVideoGameVsIceCreamPerYearScatterPlotModel()
        {
            Tuple<Matrix<double>, List<string>> exampleTwo = File2Matrix.Load();

            var largeDoses = new ScatterSeries { MarkerType = MarkerType.Circle, Title = "Liked in Large Doses" };
            var smallDoses = new ScatterSeries { MarkerType = MarkerType.Square, Title = "Liked in Small Doses" };
            var didntLike = new ScatterSeries { MarkerType = MarkerType.Triangle, Title = "Did Not Like" };

            for(var rowIdx = 0; rowIdx < exampleTwo.Item1.RowCount; rowIdx++)
            {
                var point = exampleTwo.Item1.Row(rowIdx);
                var label = exampleTwo.Item2[rowIdx];

                switch(label)
                {
                    case "largeDoses":
                        largeDoses.Points.Add(new ScatterPoint(point[PERCENT_VID_GAME], point[LITER_ICE_CREAM]));
                        break;
                    case "smallDoses":
                        smallDoses.Points.Add(new ScatterPoint(point[PERCENT_VID_GAME], point[LITER_ICE_CREAM]));
                        break;
                    case "didntLike":
                        didntLike.Points.Add(new ScatterPoint(point[PERCENT_VID_GAME], point[LITER_ICE_CREAM]));
                        break;
                    default:
                        throw new ArgumentOutOfRangeException("Unknown classification label [" + label + "] encountered.");
                }
            }

            var model = new PlotModel
            {
                Title = "Liters of Ice Cream vs. Video Game Time Scatter Plot",
                LegendBackground = OxyColor.FromAColor(200, OxyColors.White),
                LegendBorder = OxyColors.Black,
                LegendPlacement = LegendPlacement.Inside,
                LegendPosition = LegendPosition.TopLeft,
                LegendOrientation = LegendOrientation.Vertical
            };
            model.Series.Add(largeDoses);
            model.Series.Add(smallDoses);
            model.Series.Add(didntLike);
            model.Axes.Add(new LinearAxis { Key = "X", Position = AxisPosition.Bottom, Title = "Percentage of Time Spent Playing Video Games" });
            model.Axes.Add(new LinearAxis { Key = "Y", Position = AxisPosition.Left, Title = "Liters of Ice Cream Consumed Per Week" });

            MyModel = model;
        }

        public PlotModel MyModel { get; private set; }
    }
}
