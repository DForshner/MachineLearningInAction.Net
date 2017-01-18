using System;
using System.Collections.Generic;
using System.IO;
using System.Text.RegularExpressions;
using MathNet.Numerics.LinearAlgebra;

namespace kNN
{
    public static class Image2Vector
    {
        public static Tuple<IList<Vector<double>>, IList<string>> LoadAllFilesFromPath(string path)
        {
            var files = Directory.EnumerateFiles(path);
            IList<Vector<double>> dataSet = new List<Vector<double>>();
            IList<string> labels = new List<string>();
            foreach(var fullFilePath in files)
            {
                var imageData = Image2Vector.LoadFromFile(fullFilePath);
                dataSet.Add(imageData.Item1);
                labels.Add(imageData.Item2);
            }
            return Tuple.Create(dataSet, labels);
        }
        private static Tuple<Vector<double>, string> LoadFromFile(string fullFilePath)
        {
            // Gets 0_12 from 0_12.txt
            var fileNameMatch = Regex.Match(fullFilePath, @"[\d_]*(?=(.txt))");
            string fileName = fileNameMatch.ToString();
            var label = fileName.Split('_')[0];
            var data = LoadVectorFromFile(fullFilePath);

            return Tuple.Create(data, label);
        }

        private static Vector<double> LoadVectorFromFile(string file)
        {
            var toReturn = Vector<double>.Build.Dense(1024, 1.0);
            var lines = File.ReadAllLines(file);
            for (var rowIdx = 0; rowIdx < 32; ++rowIdx)
            {
                var row = lines[rowIdx];
                for (var colIdx = 0; colIdx < 32; ++colIdx)
                {
                    var writeIdx = 32 * rowIdx + colIdx;
                    toReturn[writeIdx] = double.Parse(row[colIdx].ToString());
                }
            }
            return toReturn;
        }
    }
}
