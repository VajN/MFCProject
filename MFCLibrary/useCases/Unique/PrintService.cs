namespace MFCLibrary.useCases.Unique
{
    internal static class PrintService
    {
        internal static void Print(List<string[]> lists)
        {
            foreach (string[] list in lists)
            {
                Console.WriteLine($"ID: {list[0]}| Наименование: {list[1]}");
                Console.WriteLine("==========================================");
            }
        }
    }
}
