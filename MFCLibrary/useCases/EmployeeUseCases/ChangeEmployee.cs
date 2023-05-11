

using MFCLibrary.DataBase.SqlActions;
using MFCLibrary.useCases.Unique;

namespace MFCLibrary.useCases.EmployeeUseCases
{
    internal static class ChangeEmployee
    {
        static EmployeeSql employeeSql = new EmployeeSql();

        public static void Change()
        {
            int changeId = 0;
            string newWindowNumber = "";

            PrintEmployee.PrintAll(employeeSql.TakeDataEmployee());
            while (true)
            {
                if (changeId == 0)
                {
                    Console.Write("Введите id сотрудника: ");
                    try
                    {
                        changeId = Convert.ToInt32(Console.ReadLine());
                    }
                    catch
                    {
                        Console.WriteLine("Неверный формат. Попробуйте ввести снова, либо вернитесь в меню: <...>");
                        if (Console.ReadLine() == "...")
                            break;
                        Console.Clear();
                        continue;
                    }
                    if (!employeeSql.CheckEmployee("id", changeId))
                    {
                        Console.WriteLine("Сотрудника с таким id нет в базе данных. Попробуйте ввести снова, либо вернитесь в меню: <...>");
                        changeId = 0;
                        if (Console.ReadLine() == "...")
                            return;
                        Console.Clear();
                        continue;
                    }
                    Console.Clear();
                }
                if (newWindowNumber == "")
                {
                    Console.Write("Введите новый номер окна обслуживания (от 1 до 23): ");
                    newWindowNumber = Console.ReadLine();
                    if (Convert.ToInt32(newWindowNumber) < 1 || Convert.ToInt32(newWindowNumber) > 23)
                    {
                        Console.WriteLine("Неверный формат. Попробуйте ввести снова, либо вернитесь в меню: <...>");
                        if (Console.ReadLine() == "...")
                            break;
                        newWindowNumber = "";
                        Console.Clear();
                        continue;
                    }
                    if (employeeSql.CheckEmployee("windowNumber", newWindowNumber))
                    {
                        Console.WriteLine("Данное окно обслуживания уже занято другим сотрудником. Попробуйте ввести снова, либо вернитесь в меню: <...>");
                        newWindowNumber = "";
                        if (Console.ReadLine() == "...")
                            return;
                        Console.Clear();
                        continue;
                    }
                }
                if (Convert.ToInt32(newWindowNumber) >= 21 && Convert.ToInt32(newWindowNumber) <= 23)
                    newWindowNumber = "Г" + newWindowNumber;
                employeeSql.UpdateEmployee("windowNumber", newWindowNumber, changeId);
                Console.WriteLine("Данные сотрудника изменены\n");
                break;
            }
        }
    }
}
