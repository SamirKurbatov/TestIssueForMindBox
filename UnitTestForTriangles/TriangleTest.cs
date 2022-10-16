using Microsoft.VisualStudio.TestTools.UnitTesting;
using NUnit.Framework;
using TestIssueForMindBox;
using Assert = NUnit.Framework.Assert;

namespace UnitTestForTriangles
{
    [TestClass]
    public class TriangleTest
    {
        [TestCase(1, -1, 1)]
        [TestCase(1, 1, -1)]
        [TestCase(-1, 1, 1)]
        [TestCase(0, 0, 0)]
        public void InitTriangleWithErrorTest(double a, double b, double c)
        {
            Assert.Catch<ArgumentException>(() => new Triangle(a, b, c));
        }

        [TestMethod]
        public void InitTriangleTest()
        {
            // Arrange
            double a = 3d, b = 4d, c = 5d;
            // Act
            var triangle = new Triangle(a, b, c);
            // Assert
            Assert.NotNull(triangle);
            Assert.Less(Math.Abs(triangle.SideA - a), GeneralConstants.MinAccurancy);
            Assert.Less(Math.Abs(triangle.SideB - b), GeneralConstants.MinAccurancy);
            Assert.Less(Math.Abs(triangle.SideC - c), GeneralConstants.MinAccurancy);
        }

        [TestMethod]
        public void GetSquareTest()
        {
            // Arrange
            double a = 3d, b = 4d, c = 5d;
            double result = 6d;
            // Act
            var triangle = new Triangle(a, b, c);

            var square = triangle?.GetSquare();
            // Assert
            Assert.NotNull(square);
            Assert.Less(Math.Abs(square.Value - result), GeneralConstants.MinAccurancy);
        }

        [TestMethod]
        public void InitNotTriangleTest()
        {
            Assert.Catch<ArgumentException>(() => new Triangle(1, 1, 4));
        }

        [TestCase(3, 4, 3, ExpectedResult = false)]
        [TestCase(3, 4, 5 + 2e-7, ExpectedResult = false)]
        [TestCase(3, 4, 5, ExpectedResult = true)]
        [TestCase(3, 4, 5.000000001, ExpectedResult = true)]
        public bool NotRightTriangle(double a, double b, double c)
        {
            var triangle = new Triangle(a, b, c);
            var isRight = triangle.IsRightTriangle;

            return isRight;
        }
    }
}