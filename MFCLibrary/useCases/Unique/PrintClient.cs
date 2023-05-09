namespace MFCLibrary.useCases.Unique
{
    internal static class PrintClient
    {
        internal static void Print(List<string[]> lists)
        {
            foreach (string[] list in lists)
            {
                Console.WriteLine($"ID: {list[0]}| ФИО: {list[1]}| Паспорт: {list[2]}");
                Console.WriteLine("==========================================");
            }
        }
        internal static void Print(List<string[]> lists, int id)
        {
            foreach (string[] list in lists)
            {
                if (Convert.ToInt32(list[0]) == id)
                {
                    Console.WriteLine($"ID: {list[0]}| ФИО: {list[1]}| Паспорт: {list[2]}");
                    Console.WriteLine("==========================================");
                }
            }
        }
    }
}
