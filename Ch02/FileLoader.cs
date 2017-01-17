using System;
using System.Collections.Generic;
using System.IO;
using MathNet.Numerics.LinearAlgebra;

namespace kNN
{
    static class FileLoader
    {
        const int FREQ_FLYER = 0;
        const int PERCENT_VID_GAME = 1;
        const int LITER_ICE_CREAM = 2;
        const int LABEL = 3;

        public static Tuple<Matrix<double>, List<string>> Load()
        {
            var file = Directory.GetCurrentDirectory() + "\\datingTestSet.txt";
            var lines = File.ReadAllLines(file);

            var features = new List<double[]>();
            var labels = new List<string>();
            foreach(var line in lines)
            {
                var cols = line.Split(null);
                var feature1 = Double.Parse(cols[FREQ_FLYER]);
                var feature2 = Double.Parse(cols[PERCENT_VID_GAME]);
                var feature3 = Double.Parse(cols[LITER_ICE_CREAM]);
                features.Add(new[] { feature1, feature2, feature3 });
                labels.Add(cols[LABEL]);
            }

            var m = Matrix<double>.Build.DenseOfRowArrays(features);

            return Tuple.Create(m, labels);
        }
    }
}
