using MFCLibrary.DataBase.SqlActions;
using MFCLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace MFCLibrary.useCases.EmployeeUseCases
{
    internal static class AddEmployee
    {
        static EmployeeSql employeeSql { get; } = new EmployeeSql();
        static Employee? employee;

        static string? fullnameEmployee = "";
        static int windowNumber = 0;
        static DateOnly birthday = new DateOnly();

        internal static void Add()
        {
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
                    Console.Write("Введите номер окна обслуживания (от 1 до 20): ");
                    windowNumber = Convert.ToInt32(Console.ReadLine());
                    if (windowNumber < 1 || windowNumber > 20)
                    {
                        Console.WriteLine("Неверный формат. Попробуйте ввести снова, либо вернитесь в меню: <...>");
                        windowNumber = 0;
                        if (Console.ReadLine() == "...")
                            return;
                        continue;
                    }
                    if (employeeSql.CheckEmployee(windowNumber))
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
            Employee employee = new Employee(fullnameEmployee, birthday, windowNumber);
            employeeSql.AddEmployee(employee);
            Console.WriteLine("Сотрудник добавлен в базу данных\n");
        }
    }
}
