using MFCLibrary.Data.Models;
using MFCLibrary.DataBase.SqlActions;


namespace MFCLibrary.useCases.EmployeeUseCases
{
    internal static class AddEmployee
    {
        static private EmployeeSql employeeSql = new EmployeeSql();
        static private Employee? employee;

        internal static void Add()
        {
            string fullnameEmployee = "";
            int windowNumber = 0;
            DateOnly birthday = new DateOnly();

            while (true)
            {
                if (fullnameEmployee == "")
                {
                    Console.Write("Введите ФИО сотрудника: ");
                    fullnameEmployee = Console.ReadLine();
                    continue;
                }

                if (birthday == DateOnly.Parse("01.01.0001"))
                {
                    Console.Write("Введите дату рождения (формат ДД.ММ.ГГГГ): ");
                    try
                    {
                        birthday = DateOnly.Parse(Console.ReadLine());
                    }
                    catch
                    {
                        Console.WriteLine("Неверный формат. Попробуйте ввести снова, либо вернитесь в меню: <...>");
                        if (Console.ReadLine() == "...")
                            return;
                        continue;
                    }
                }
                if (windowNumber == 0)
                {
                    Console.Write("Введите номер окна обслуживания (от 1 до 23): ");
                    try
                    {
                        windowNumber = Convert.ToInt32(Console.ReadLine());
                    }
                    catch
                    {
                        Console.WriteLine("Неверный формат. Попробуйте ввести снова, либо вернитесь в меню: <...>");
                        windowNumber = 0;
                        if (Console.ReadLine() == "...")
                            return;
                        continue;
                    }
                    if (windowNumber < 1 || windowNumber > 23)
                    {
                        Console.WriteLine("Неверный формат. Попробуйте ввести снова, либо вернитесь в меню: <...>");
                        windowNumber = 0;
                        if (Console.ReadLine() == "...")
                            return;
                        continue;
                    }
                    if (employeeSql.CheckEmployee("windowNumber", Convert.ToString(windowNumber)))
                    {
                        Console.WriteLine("Данное окно обслуживания уже числится за другим сотрудником. Попробуйте ввести снова, либо вернитесь в меню: <...>");
                        windowNumber = 0;
                        if (Console.ReadLine() == "...")
                            return;
                        continue;
                    }
                }
                break;
            }
            if(windowNumber >= 21 && windowNumber <= 23)
                employee = new Employee(fullnameEmployee, birthday, "Г" + Convert.ToString(windowNumber));
            else
                employee = new Employee(fullnameEmployee, birthday, Convert.ToString(windowNumber));
            employeeSql.AddEmployee(employee);
            Console.WriteLine("Сотрудник добавлен в базу данных\n");
        }
    }
}
