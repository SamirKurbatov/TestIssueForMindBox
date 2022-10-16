namespace TestIssueForMindBox
{
    public class Triangle : ITriangle
    {
        /// <summary>
        /// Объявляем поля которые содержат текст ошибок
        /// чтобы не повторять их в теле условных конструкций для проверки условия
        /// </summary>
        private readonly string triangleSideError = "Неверно указана сторона!";
        private readonly string triangleMaxSiedError = "Наибольшая сторона треугольника должна быть меньше суммы других сторон!";

        public Triangle(double sideA, double sideB, double sideC)
        {
            if (sideA < GeneralConstants.MinAccurancy)
                throw new ArgumentException(triangleSideError, nameof(sideA));
            if (sideB < GeneralConstants.MinAccurancy)
                throw new ArgumentException(triangleSideError, nameof(sideB));
            if (sideC < GeneralConstants.MinAccurancy)
                throw new ArgumentException(triangleSideError, nameof(sideC));

            var perimetr = sideA + sideB + sideC;
            var maxSide = Math.Max(SideA, Math.Max(sideB, sideC));
            if ((perimetr - maxSide) - maxSide < GeneralConstants.MinAccurancy)
                throw new ArgumentException(triangleMaxSiedError);

            SideA = sideA;
            SideB = sideB;
            SideC = sideC;

            _isRightTriangle = new Lazy<bool>(GetIsRightTriangle);
        }


        public double SideA { get; }

        public double SideB { get; }

        public double SideC { get; }

        private readonly Lazy<bool> _isRightTriangle;
        public bool IsRightTriangle => _isRightTriangle.Value;

        private bool GetIsRightTriangle()
        {
            double maxSide = SideA, 
                   sideB = SideB, 
                   sideC = SideC;
            if (SideB - maxSide > GeneralConstants.MinAccurancy)
            {
                Functions.Swap(ref maxSide, ref sideB);
            }

            if (SideC - maxSide > GeneralConstants.MinAccurancy)
            {
                Functions.Swap(ref maxSide, ref sideC);
            }

            return Math.Abs(Math.Pow(maxSide, 2) - Math.Pow(sideB, 2) - Math.Pow(sideC, 2)) < GeneralConstants.MinAccurancy;
        }

        public double GetSquare()
        {
            var halfP = (SideA + SideB + SideC) / 2d;
            var square = Math.Sqrt(halfP * (halfP - SideA) * (halfP - SideB) * (halfP - SideC));
            return square;
        }
    }
}
