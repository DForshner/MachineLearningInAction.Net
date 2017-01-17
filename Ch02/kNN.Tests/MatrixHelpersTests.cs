using System;
using MathNet.Numerics.LinearAlgebra;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace kNN.Tests
{
    [TestClass]
    public class MatrixHelpersTests
    {
        [TestMethod]
        public void Tile_ExpectRowVectorTiled()
        {
            var v = Vector<double>.Build.DenseOfArray(new[] { 1.0, 2.0, 3.0 });

            var result = MatrixHelpers.Tile(v, 3);

            Assert.AreEqual(1.0, result[0, 0]);
            Assert.AreEqual(2.0, result[0, 1]);
            Assert.AreEqual(3.0, result[0, 2]);
            Assert.AreEqual(1.0, result[2, 0]);
            Assert.AreEqual(2.0, result[2, 1]);
            Assert.AreEqual(3.0, result[2, 2]);
        }

        [TestMethod]
        public void DetermineMinMaxValues_ExpectMinMaxVectorsReturned()
        {
            var m = Matrix<double>.Build.DenseOfArray(new[,] {
                { 1.0, 10.0, 100.0 },
                { 2.0, 20.0, 200.0 },
                { 3.0, 30.0, 300.0 }
            });

            var result = MatrixHelpers.DetermineMinMaxValues(m);

            var min = result.Item1;
            Assert.AreEqual(1.0, min[0]);
            Assert.AreEqual(10.0, min[1]);
            Assert.AreEqual(100.0, min[2]);
            var max = result.Item2;
            Assert.AreEqual(3.0, max[0]);
            Assert.AreEqual(30.0, max[1]);
            Assert.AreEqual(300.0, max[2]);
        }

        [TestMethod]
        public void Normalize_WhenOnlyTwoValsPerFeature_ExpectGreaterValIsNormalizedToOne()
        {
            var m = Matrix<double>.Build.DenseOfArray(new[,] {
                { 5.0, 10.0, 500.0 },
                { 2.0, 50.0, 200.0 },
            });

            var result = MatrixHelpers.Normalize(m);

            Assert.AreEqual(1.0, result[0, 0]);
            Assert.AreEqual(1.0, result[1, 1]);
            Assert.AreEqual(1.0, result[0, 2]);
        }
    }
}
