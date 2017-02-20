using System;
using System.Collections.Generic;
using MathNet.Numerics.LinearAlgebra;

namespace Regression
{
    public static class RegressionCalculator
    {
        public static Matrix<double> DetermineStandardRegression(Matrix<double> xMatrix, List<double> yArr)
        {
            var xTransposeX = xMatrix.Transpose().Multiply(xMatrix);
            if (xTransposeX.Determinant() == 0.0)
            {
                throw new ArgumentException("This matrix is singular, cannot do inverse.");
            }

            var yMatrix = Matrix<double>.Build.DenseOfRows(new[] { yArr }).Transpose();
            Matrix<double> rhs = xMatrix.Transpose().Multiply(yMatrix);
            Matrix<double> weights = xTransposeX.Inverse().Multiply(rhs);
            return weights;
        }
    }
}
