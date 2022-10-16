using TestIssueForMindBox;

namespace TestProjectForTriange
{
    public class TriangleTests
    {
        [TestCase(-1, 1, 1)]
        [TestCase(1, -1, 1)]
        [TestCase(1, 1, -1)]
        [TestCase(0, 0, 0)]
        public void InitTriangleWithErrorTest(double a, double b, double c)
        {
            Assert.Catch<ArgumentException>(() => new Triangle(a, b, c));
        }

        [Test]
        public void InitTriangleTest()
        {
            // Data.
            double a = 3d, b = 4d, c = 5d;

            // Act.
            var triangle = new Triangle(a, b, c);

            // Assert.
            Assert.NotNull(triangle);
            Assert.Less(Math.Abs(triangle.SideA - a), GeneralConstants.Accuracy);
            Assert.Less(Math.Abs(triangle.SideB - b), GeneralConstants.Accuracy);
            Assert.Less(Math.Abs(triangle.SideC - c), GeneralConstants.Accuracy);
        }

        [Test]
        public void GetSquareTest()
        {
            // Data.
            double a = 3d, b = 4d, c = 5d;
            double result = 6d;
            var triangle = new Triangle(a, b, c);

            // Act.
            var square = triangle?.GetSquare();

            // Assert.
            Assert.NotNull(square);
            Assert.Less(Math.Abs(square.Value - result), GeneralConstants.Accuracy);
        }

        [Test]
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
            // Data.
            var triangle = new Triangle(a, b, c);

            // Act.
            var isRight = triangle.IsRightTriangle;

            // Assert. 
            return isRight;
        }
    }
}