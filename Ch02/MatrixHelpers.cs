using System;
using System.Linq;
using MathNet.Numerics.LinearAlgebra;

namespace kNN
{
    public class MatrixHelpers
    {
        public static Vector<double> GetEuclidianDistance(Matrix<double> a, Matrix<double> b)
        {
            var diffMatrix = a - b;
            var sqDiffMatrix = diffMatrix.PointwisePower(2);
            var sqDistances = sqDiffMatrix.RowSums();
            return sqDistances.PointwisePower(0.5);
        }

        public static Matrix<double> Tile(Vector<double> rowToCopy, int numRows)
        {
            return Matrix<double>.Build.DenseOfRowVectors(Enumerable.Repeat(rowToCopy, numRows));
        }

        public static Matrix<double> Normalize(Matrix<double> rawFeatures)
        {
            var minMax = DetermineMinMaxValues(rawFeatures);
            Vector<double> featureMinVals = minMax.Item1;
            Vector<double> featureMaxVals = minMax.Item2;
            Vector<double> ranges = featureMaxVals - featureMinVals;

            var zeroedDataSet = Matrix<double>.Build.Dense(rawFeatures.RowCount, rawFeatures.ColumnCount, 0.0);
            var minMatrix = Tile(featureMinVals, rawFeatures.RowCount);
            var minusMin = zeroedDataSet + rawFeatures - minMatrix;

            var rangeMatrix = Tile(ranges, rawFeatures.RowCount);
            return minusMin.PointwiseDivide(rangeMatrix);
        }

        public static Tuple<Vector<double>, Vector<double>> DetermineMinMaxValues(Matrix<double> rawFeatures)
        {
            int numFeatures = rawFeatures.ColumnCount;
            var featureMinVals = Vector<double>.Build.DenseOfEnumerable(Enumerable.Repeat(double.MaxValue, numFeatures));
            var featureMaxVals = Vector<double>.Build.DenseOfEnumerable(Enumerable.Repeat(double.MinValue, numFeatures));
            for (var rowIdx = 0; rowIdx < rawFeatures.RowCount; ++rowIdx)
            {
                var row = rawFeatures.Row(rowIdx);
                for (var colIdx = 0; colIdx < rawFeatures.ColumnCount; ++colIdx)
                {
                    var val = row[colIdx];
                    if (val < featureMinVals[colIdx]) { featureMinVals[colIdx] = val; }
                    if (val > featureMaxVals[colIdx]) { featureMaxVals[colIdx] = val; }
                }
            }
            return Tuple.Create(featureMinVals, featureMaxVals);
        }
    }
}
