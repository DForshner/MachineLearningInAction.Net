using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
            Tuple<Matrix<double>, List<double>> exampleZero = File2Matrix.Load();
            var pointsSeries = new ScatterSeries { MarkerType = MarkerType.Circle, Title = "Example Data" };
            for (var rowIdx = 0; rowIdx < exampleZero.Item1.RowCount; rowIdx++)
            {
                var point = exampleZero.Item1.Row(rowIdx);
                var label = exampleZero.Item2[rowIdx];
                pointsSeries.Points.Add(new ScatterPoint(point[X2], label));
            }

            var sortedXRows = exampleZero.Item1.EnumerateRows()
                .OrderBy(x => x.ElementAt(1));
            var sortedXMatrix = Matrix<double>.Build.DenseOfRows(sortedXRows);
            var weights = RegressionCalculator.DetermineStandardRegression(sortedXMatrix, exampleZero.Item2);
            var yHat = sortedXMatrix.Multiply(weights);
            var bestFitSeries = new LineSeries { };
            for (var rowIdx = 0; rowIdx < exampleZero.Item2.Count; rowIdx++)
            {
                var x = sortedXMatrix.Row(rowIdx).ElementAt(1);
                var y = yHat.Row(rowIdx).ElementAt(0);
                bestFitSeries.Points.Add(new DataPoint(x, y));
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
            model.Series.Add(pointsSeries);
            model.Series.Add(bestFitSeries);
            model.Axes.Add(new LinearAxis { Key = "X", Position = AxisPosition.Bottom, Title = "x" });
            model.Axes.Add(new LinearAxis { Key = "Y", Position = AxisPosition.Left, Title = "y" });

            MyModel = model;
        }

        public PlotModel MyModel { get; private set; }
    }
}
