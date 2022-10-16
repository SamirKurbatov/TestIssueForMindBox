namespace TestIssueForMindBox
{
    internal static class Functions
    {
        internal static void Swap<T>(ref T sideA, ref T sideB)
        {
            T temp = sideA;
            sideA = sideB;
            sideB = temp;
        }
    }
}
