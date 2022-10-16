namespace TestIssueForMindBox
{
    /// <summary>
    /// Интерфейса для реализации получения свойств конкретной фигуры треугольника
    /// </summary>
    public interface ITriangle : IShape
    {
        bool IsRightTriangle { get; }

        double SideA { get; }
        double SideB { get; }
        double SideC { get; }
    }
}
