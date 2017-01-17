using System;
using System.Collections.Generic;
using MathNet.Numerics.LinearAlgebra;
using OxyPlot;
using OxyPlot.Series;

namespace kNN
{
    public class MainViewModel
    {
        public MainViewModel()
        {
            Tuple<Matrix<double>, List<string>> exampleTwo = FileLoader.Load();

            KNNClassifier.Classify();

            this.MyModel = new PlotModel { Title = "Example 1" };
            this.MyModel.Series.Add(new FunctionSeries(Math.Cos, 0, 10, 0.1, "cos(x)"));
        }

        public PlotModel MyModel { get; private set; }
    }
}
