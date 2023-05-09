

using MFCLibrary.DataBase.SqlActions;
using MFCLibrary.useCases.Unique;

namespace MFCLibrary.useCases.EmployeeUseCases
{
    internal static class ChangeEmployee
    {
        static EmployeeSql employeeSql = new EmployeeSql();

        static int changeId = 0;
        static int newWindowNumber = 0;
        public static void Change()
        {
            PrintEmployee.Print(employeeSql.TakeDataEmployee());
            while (true)
            {
                if (changeId == 0)
                {
                    Console.Write("Введите id сотрудника: ");
                    changeId = Convert.ToInt32(Console.ReadLine());
                    if (!employeeSql.CheckEmployee("id", changeId))
                    {
                        Console.WriteLine("Сотрудника с таким id нет в базе данных. Попробуйте ввести снова, либо вернитесь в меню: <...>");
                        changeId = 0;
                        if (Console.ReadLine() == "...")
                            return;
                        continue;
                    }
                }
                if (newWindowNumber == 0)
                {
                    Console.Write("Введите новый номер окна обслуживания (от 1 до 20): ");
                    newWindowNumber = Convert.ToInt32(Console.ReadLine());
                    if (newWindowNumber < 1 || newWindowNumber > 20)
                    {
                        Console.WriteLine("Неверный формат. Попробуйте ввести снова, либо вернитесь в меню: <...>");
                        if (Console.ReadLine() == "...")
                            break;
                        newWindowNumber = 0;
                        continue;
                    }
                    if (employeeSql.CheckEmployee("windowNumber", newWindowNumber))
                    {
                        Console.WriteLine("Данное окно обслуживания уже занято другим сотрудником. Попробуйте ввести снова, либо вернитесь в меню: <...>");
                        newWindowNumber = 0;
                        if (Console.ReadLine() == "...")
                            return;
                        continue;
                    }
                }
                break;
            }
            employeeSql.UpdateEmployee("windowNumber", newWindowNumber, changeId);
            Console.WriteLine("Данные сотрудника изменены\n");
        }
    }
}
