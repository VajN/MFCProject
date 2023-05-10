namespace MFCLibrary.useCases.Unique
{
    internal static class PrintClient
    {
        internal static void PrintAll(List<string[]> lists)
        {
            foreach (string[] list in lists)
            {
                Console.WriteLine($"ID: {list[0]}| ФИО: {list[1]}| Паспорт: {list[2]}");
                Console.WriteLine("==========================================");
            }
        }
        internal static void PrintOrdinary(List<string[]> lists)
        {
            foreach (string[] list in lists)
            {
                if (!Convert.ToBoolean(list[3]))
                {
                    Console.WriteLine($"ID: {list[0]}| ФИО: {list[1]}| Паспорт: {list[2]}");
                    Console.WriteLine("==========================================");
                }
            }
        }
        internal static void PrintSpecial(List<string[]> lists)
        {
            foreach (string[] list in lists)
            {
                if (Convert.ToBoolean(list[3]))
                {
                    Console.WriteLine($"ID: {list[0]}| ФИО: {list[1]}| Паспорт: {list[2]}");
                    Console.WriteLine("==========================================");
                }
            }
        }
        internal static void PrintById(List<string[]> lists, int id)
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
