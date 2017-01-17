﻿using System;
using System.Collections.Generic;
using System.Linq;
using MathNet.Numerics.LinearAlgebra;

namespace kNN
{
    public static class KNNClassifier
    {
        private static Matrix<double> CreateGroup()
        {
            double[,] x = {{ 1.0, 1.1 }, { 1.0, 1.0 }, { 0, 0 }, { 0, 0.1 } };
            return Matrix<double>.Build.DenseOfArray(x);
        }

        private static IList<string> CreateLabels()
        {
            return new[] { "A", "A", "B", "B" };
        }

        /// <summary>
        /// Classify an input vector against a labeled dataset using kNN.
        /// </summary>
        /// <param name="inX">input vector to classify</param>
        /// <param name="dataSet">full matrix of training examples</param>
        /// <param name="labels">vector of labels</param>
        /// <param name="k">the number of nearest neighbors to use in the voting</param>
        /// <returns>The classification label of the input vector</returns>
        private static string Classify(Vector<double> inX, Matrix<double> dataSet, IList<string> labels, int k)
        {
            Vector<double> distances = GetEuclidianDistance(inX, dataSet);
            IDictionary<string, int> freqByClassLabel = CountClassFrequency(labels, k, distances);
            var mostPopularClass = freqByClassLabel
                .OrderByDescending(x => x.Value)
                .First()
                .Key;
            return mostPopularClass;
        }

        private static Vector<double> GetEuclidianDistance(Vector<double> inX, Matrix<double> dataSet)
        {
            int dataSetSize = dataSet.RowCount;
            Matrix<double> a = MatrixHelpers.Tile(inX, dataSetSize);
            return MatrixHelpers.GetEuclidianDistance(a, dataSet);
        }

        private static Dictionary<string, int> CountClassFrequency(IList<string> labels, int k, Vector<double> distances)
        {
            var sortedIndicies = distances
                .Select((val, idx) => new { val = val, idx = idx })
                .OrderBy(x => x.val)
                .Select(x => x.idx)
                .ToList();
            var classCount = new Dictionary<string, int>();
            for (int i = 0; i < k; ++i)
            {
                var idx = sortedIndicies[i];
                var voteLabel = labels[idx];
                if (!classCount.ContainsKey(voteLabel)) { classCount.Add(voteLabel, 0); }
                classCount[voteLabel] += 1;
            }

            return classCount;
        }

        internal static double GetErrorRate()
        {
            double hoRatio = 0.10;

            Tuple<Matrix<double>, List<string>> exampleTwo = FileLoader.Load();
            var group = exampleTwo.Item1;
            var labels = exampleTwo.Item2;

            var normalizedDataSet = MatrixHelpers.Normalize(group);
            var numTestVectors = (int)((double)group.RowCount * hoRatio);
            int errorCount = 0;
            for (var i = 0; i < numTestVectors; ++i)
            {
                var toTest = normalizedDataSet.Row(i);
                var dataSet = normalizedDataSet;

                var classifierResult = Classify(toTest, dataSet, labels, 3);
                var actualResult = labels[i];
                if (classifierResult != actualResult) { errorCount += 1; }
            }

            return errorCount / (double)numTestVectors;
        }

        public static void Classify()
        {
            var inX = Vector<double>.Build.Dense(new[] { 0.9, 0.9 });
            var group = CreateGroup();
            var labels = CreateLabels();

            Classify(inX, group, labels, 3);
        }
    }
}