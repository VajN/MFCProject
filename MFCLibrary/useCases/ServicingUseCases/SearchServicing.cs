using MFCLibrary.DataBase.SqlActions;
using MFCLibrary.useCases.Unique;

namespace MFCLibrary.useCases.ServicesUseCases
{
    internal static class SearchServicing
    {
        static ClientSql clientSql = new ClientSql();
        static EmployeeSql employeeSql = new EmployeeSql();
        static ServicingSql servicingSql = new ServicingSql();

        public static void Search()
        {
            string criteria = "";
            string search = "";
            string numberQueue = "";
            int id = 0;
            DateOnly date;

            while (true)
            {
                if (criteria == "")
                {
                    Console.WriteLine("Критерии поиска операции обслуживания:\n1.ФИО клиента\n2.ФИО сотрудника\n3.Дата обслуживания и номер талона: ");
                    Console.Write("\nВыберите критерий: ");
                    criteria = Console.ReadLine();
                }
                if (criteria == "1")
                {
                    Console.Write("\nВведите ФИО клиента: ");
                    search = Console.ReadLine();

                    if (!clientSql.CheckClient("fullnameClient", search))
                    {
                        Console.WriteLine("Клиента с таким ФИО нет в базе данных. Попробуйте ввести снова, либо вернитесь в меню: <...>");
                        search = "";
                        if (Console.ReadLine() == "...")
                            return;
                        continue;
                    }
                    if (search == "")
                    {
                        Console.WriteLine("Необходимо ввести ФИО клиента. Попробуйте ввести снова, либо вернитесь в меню: <...>");
                        if (Console.ReadLine() == "...")
                            return;
                        continue;
                    }
                    id = Convert.ToInt32(clientSql.TakeValueClient("id", "fullnameClient", search));
                    Console.Clear();
                    Console.WriteLine("Оказанные услуги:\n");
                    PrintServicing.Print(servicingSql.TakeDataServicing(), "clientId", id);
                }
                if (criteria == "2")
                {
                    Console.Write("\nВведите ФИО сотрудника: ");
                    search = Console.ReadLine();

                    if (!employeeSql.CheckEmployee("fullnameEmployee", search))
                    {
                        Console.WriteLine("Сотрудника с таким ФИО нет в базе данных. Попробуйте ввести снова, либо вернитесь в меню: <...>");
                        search = "";
                        if (Console.ReadLine() == "...")
                            return;
                        continue;
                    }
                    if (search == "")
                    {
                        Console.WriteLine("Необходимо ввести ФИО сотрудника. Попробуйте ввести снова, либо вернитесь в меню: <...>");
                        if (Console.ReadLine() == "...")
                            return;
                        continue;
                    }
                    id = Convert.ToInt32(employeeSql.TakeValueEmployee("id", "fullnameEmployee", search));
                    Console.Clear();
                    Console.WriteLine("Оказанные услуги:\n");
                    PrintServicing.Print(servicingSql.TakeDataServicing(), "employeeId", id);
                }
                if (criteria == "3")
                {
                    Console.Write("\nВведите дату обслуживания (формат ДД.ММ.ГГГГ): ");
                    try
                    {
                        date = DateOnly.Parse(Console.ReadLine());
                    }
                    catch
                    {
                        Console.WriteLine("Неверный формат. Попробуйте ввести снова, либо вернитесь в меню: <...>");
                        if (Console.ReadLine() == "...")
                            return;
                        continue;
                    }
                    Console.WriteLine("Введите номер талона (формат XNNN: X - первая буква наименования услуги, N – порядковый номер талона за текущий день): ");
                    numberQueue = Console.ReadLine();
                    if (numberQueue == "")
                    {
                        Console.WriteLine("Необходимо ввести номер талона. Попробуйте ввести снова, либо вернитесь в меню: <...>");
                        if (Console.ReadLine() == "...")
                            return;
                        continue;
                    }
                    if (!char.IsLetter(numberQueue[0]))
                    {
                        Console.WriteLine("Неверный формат. Попробуйте ввести снова, либо вернитесь в меню: <...>");
                        if (Console.ReadLine() == "...")
                            return;
                        continue;
                    }
                    for (int i = 1; i < 4; i++)
                    {
                        if (!char.IsDigit(numberQueue[i]))
                        {
                            Console.WriteLine("Неверный формат. Попробуйте ввести снова, либо вернитесь в меню: <...>");
                            if (Console.ReadLine() == "...")
                                return;
                            continue;
                        }
                    }
                    Console.Clear();
                    Console.WriteLine("Оказанная услуга:\n");
                    Print(servicingSql.TakeDataServicing(), Convert.ToString(date), numberQueue);
                }
                if (criteria == "")
                {
                    Console.WriteLine("Необходимо выбрать критерий поиска. Попробуйте ввести снова, либо вернитесь в меню: <...>");
                    if (Console.ReadLine() == "...")
                        return;
                    Console.Clear();
                    continue;
                }
                break;
            }
        }

        private static void Print(List<string[]> lists, string date, string numberQueue)
        {
            string fullnameEmployee;
            string fullnameClient;

            foreach (string[] list in lists)
            {
                if (list[2] == date && list[6] == numberQueue)
                {
                    fullnameEmployee = employeeSql.TakeValueEmployee("fullnameEmployee", "id", list[0]);
                    fullnameClient = clientSql.TakeValueClient("fullnameClient", "id", list[5]);
                    Console.WriteLine($"{list[2]} {list[3]}| Талон: {list[6]}| Услуга: {list[4]}| Окно: {list[1]}| Сотрудник: {fullnameEmployee}({list[0]})| Клиент: {fullnameClient}({list[5]})");
                    Console.WriteLine("==========================================");
                }
            }
        }
    }
}
