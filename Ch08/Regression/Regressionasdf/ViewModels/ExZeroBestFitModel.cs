using System;
using System.Collections.Generic;
using MathNet.Numerics.LinearAlgebra;
using OxyPlot;
using OxyPlot.Axes;
using OxyPlot.Series;

namespace Regression.ViewModels
{
    public class ExZeroBestFitModel
    {
        const int X1 = 0;
        const int X2 = 1;
        const int Y = 2;

        public ExZeroBestFitModel()
        {
            Tuple<Matrix<double>, List<double>> exampleTwo = File2Matrix.Load();
            var series = new ScatterSeries { MarkerType = MarkerType.Circle, Title = "Liked in Large Doses" };
            for(var rowIdx = 0; rowIdx < exampleTwo.Item1.RowCount; rowIdx++)
            {
                var point = exampleTwo.Item1.Row(rowIdx);
                var label = exampleTwo.Item2[rowIdx];
                series.Points.Add(new ScatterPoint(point[X1], label));
            }
            var model = new PlotModel
            {
                Title = "Example data from file ex0.txt",
                LegendBackground = OxyColor.FromAColor(200, OxyColors.White),
                LegendBorder = OxyColors.Black,
                LegendPlacement = LegendPlacement.Inside,
                LegendPosition = LegendPosition.TopLeft,
                LegendOrientation = LegendOrientation.Vertical
            };
            model.Series.Add(series);
            model.Axes.Add(new LinearAxis { Key = "X", Position = AxisPosition.Bottom, Title = "x" });
            model.Axes.Add(new LinearAxis { Key = "Y", Position = AxisPosition.Left, Title = "y" });

            MyModel = model;
        }

        public PlotModel MyModel { get; private set; }
    }
}
