using System;
using System.Linq;
using System.Collections.Generic;
using MathNet.Numerics.LinearAlgebra;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Regression.Tests
{
    [TestClass]
    public class RegressionCalculatorTests
    {
        [TestMethod]
        public void WhenLinearWithNoOffset_ExpectLinearRegression()
        {
            double[,] x = { { 0.0 }, { 1.0 }, { 2.0 }, { 3.0 } };
            var xMatrix = Matrix<double>.Build.DenseOfArray(x);
            var y = new List<double> {  0.0, 1.0, 2.0, 3.0 };

            var actual = RegressionCalculator.DetermineStandardRegression(xMatrix, y);

            Assert.AreEqual(1.0, actual.Row(0).ElementAt(0), 0.001);
        }

        /// <summary>
        /// y = 3x + 2;
        /// </summary>
        [TestMethod]
        public void WhenLinearWithOffset_ExpectLinearRegression()
        {
            double[,] x = { { 0.0 }, { 1.0 }, { 2.0 }, { 3.0 } };
            var xMatrix = Matrix<double>.Build.DenseOfArray(x);
            var y = new List<double> { 2.0, 5.0, 8.0, 11.0 };

            var actual = RegressionCalculator.DetermineStandardRegression(xMatrix, y);

            Assert.AreEqual(1.0, actual.Row(0).ElementAt(0), 0.001);
        }
    }
}