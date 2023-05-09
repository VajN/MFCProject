using MFCLibrary.DataBase.SqlActions;

namespace MFCLibrary.useCases.Unique
{
    internal static class PrintAutorizedServicing
    {
        static EmployeeSql employeeSql = new EmployeeSql();
        static ClientSql clientSql = new ClientSql();

        static string fullnameEmployee = "";
        static string fullnameClient = "";
        internal static void Print(List<string[]> lists, string row, int id)
        {
            foreach (string[] list in lists)
            {
                if (row == "employeeId")
                {
                    if (Convert.ToInt32(list[0]) == id)
                    {
                        fullnameEmployee = employeeSql.TakeValueEmployee("fullnameEmployee", "id", list[0]);
                        fullnameClient = clientSql.TakeValueClient("fullnameClient", "id", list[5]);
                        Console.WriteLine($"{list[2]} {list[3]}| Услуга: {list[4]}| Окно: {list[1]}| Сотрудник: {fullnameEmployee}({list[0]})| Клиент: {fullnameClient}({list[5]})");
                        Console.WriteLine("==========================================");
                    }
                }
                else if (row == "clientId")
                {
                    if (Convert.ToInt32(list[5]) == id)
                    {
                        fullnameEmployee = employeeSql.TakeValueEmployee("fullnameEmployee", "id", list[0]);
                        fullnameClient = clientSql.TakeValueClient("fullnameClient", "id", list[5]);
                        Console.WriteLine($"{list[2]} {list[3]}| Услуга: {list[4]}| Окно: {list[1]}| Сотрудник: {fullnameEmployee}({list[0]})| Клиент: {fullnameClient}({list[5]})");
                        Console.WriteLine("==========================================");
                    }
                }
            }
        }
    }
}
