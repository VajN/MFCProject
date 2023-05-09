

using MFCLibrary.DataBase.SqlActions;

namespace MFCLibrary.useCases.ServicingUseCases
{
    internal static class ViewServicingStatistics
    {
        static ServicingSql servicingSql = new ServicingSql();
        static EmployeeSql employeeSql = new EmployeeSql();
        static ClientSql clientSql = new ClientSql();

        static string criteria = "";
        static DateOnly dateOne, dateTwo;
        public static void ServicingStatistics()
        {
            while (true)
            {
                if (criteria == "")
                {
                    Console.WriteLine("Варианты поиска:\n1.Дата\n2.Диапазон дат\n3.Вся статистика");
                    Console.Write("\nВыберите критерий: ");
                    criteria = Console.ReadLine();
                }
                if (criteria == "1")
                {
                    Console.Write("\nВведите дату (формат ДД.ММ.ГГГГ): ");
                    try
                    {
                        dateOne = DateOnly.Parse(Console.ReadLine());
                    }
                    catch
                    {
                        Console.WriteLine("Неверный формат. Попробуйте ввести снова, либо вернитесь в меню: <...>");
                        if (Console.ReadLine() == "...")
                            return;
                        continue;
                    }
                    Console.Clear();
                    Console.WriteLine("Статистика обслуживания:\n");
                    PrintByDate(servicingSql.TakeDataServicing(), dateOne);
                }
                if (criteria == "2")
                {
                    Console.WriteLine("\nВведите даты (формат ДД.ММ.ГГГГ): ");
                    Console.Write("От: ");
                    try
                    {
                        dateOne = DateOnly.Parse(Console.ReadLine());
                    }
                    catch
                    {
                        Console.WriteLine("Неверный формат. Попробуйте ввести снова, либо вернитесь в меню: <...>");
                        if (Console.ReadLine() == "...")
                            return;
                        continue;
                    }
                    Console.Write("До: ");
                    try
                    {
                        dateTwo = DateOnly.Parse(Console.ReadLine());
                    }
                    catch
                    {
                        Console.WriteLine("Неверный формат. Попробуйте ввести снова, либо вернитесь в меню: <...>");
                        if (Console.ReadLine() == "...")
                            return;
                        continue;
                    }
                    Console.Clear();
                    Console.WriteLine("Статистика обслуживания:\n");
                    PrintByRangeDate(servicingSql.TakeDataServicing(), dateOne, dateTwo);
                }
                if (criteria == "3")
                {
                    Console.Clear();
                    Console.WriteLine("Статистика обслуживания:\n");
                    PrintAll(servicingSql.TakeDataServicing());
                }
                criteria = "";
                break;
            }
        }
        private static void PrintByDate(List<string[]> lists, DateOnly date)
        {
            string fullnameEmployee;
            string fullnameClient;

            foreach (string[] list in lists)
            {
                if (DateOnly.Parse(list[2]) == date)
                {
                    fullnameEmployee = employeeSql.TakeValueEmployee("fullnameEmployee", "id", list[0]);
                    fullnameClient = clientSql.TakeValueClient("fullnameClient", "id", list[5]);
                    Console.WriteLine($"{list[3]}| Талон: {list[6]}| Услуга: {list[4]}| Окно: {list[1]}| Сотрудник: {fullnameEmployee}({list[0]})| Клиент: {fullnameClient}({list[5]})");
                    Console.WriteLine("==========================================");
                }
            }
        }
        private static void PrintByRangeDate(List<string[]> lists, DateOnly dateOne, DateOnly dateTwo)
        {
            string fullnameEmployee;
            string fullnameClient;

            foreach (string[] list in lists)
            {
                if (DateOnly.Parse(list[2]) >= dateOne && DateOnly.Parse(list[2]) <= dateTwo)
                {
                    fullnameEmployee = employeeSql.TakeValueEmployee("fullnameEmployee", "id", list[0]);
                    fullnameClient = clientSql.TakeValueClient("fullnameClient", "id", list[5]);
                    Console.WriteLine($"{list[2]} {list[3]}| Талон: {list[6]}| Услуга: {list[4]}| Окно: {list[1]}| Сотрудник: {fullnameEmployee}({list[0]})| Клиент: {fullnameClient}({list[5]})");
                    Console.WriteLine("==========================================");
                }
            }
        }
        private static void PrintAll(List<string[]> lists)
        {
            string fullnameEmployee;
            string fullnameClient;
            int count = 0;
            foreach (string[] list in lists)
            {
                fullnameEmployee = employeeSql.TakeValueEmployee("fullnameEmployee", "id", list[0]);
                fullnameClient = clientSql.TakeValueClient("fullnameClient", "id", list[5]);
                Console.WriteLine($"{list[3]}| Талон: {list[6]}| Услуга: {list[4]}| Окно: {list[1]}| Сотрудник: {fullnameEmployee}({list[0]})| Клиент: {fullnameClient}({list[5]})");
                Console.WriteLine("==========================================");
                count++;
            }
            Console.WriteLine($"Всего: {count}");
        }
    }
}
