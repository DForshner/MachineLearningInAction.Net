using System;
using System.Collections.Generic;
using System.IO;
using MathNet.Numerics.LinearAlgebra;

namespace Regression
{
    public static class File2Matrix
    {
        const int X1 = 0;
        const int X2 = 1;
        const int Y = 2;

        public static Tuple<Matrix<double>, List<double>> Load()
        {
            var file = Directory.GetCurrentDirectory() + "\\ex0.txt";
            var lines = File.ReadAllLines(file);

            var features = new List<double[]>();
            var labels = new List<double>();
            foreach (var line in lines)
            {
                var cols = line.Split(null);
                var feature1 = Double.Parse(cols[X1]);
                var feature2 = Double.Parse(cols[X2]);
                features.Add(new[] { feature1, feature2 });

                var label = Double.Parse(cols[Y]);
                labels.Add(label);
            }

            var m = Matrix<double>.Build.DenseOfRowArrays(features);
            return Tuple.Create(m, labels);
        }
    }
}