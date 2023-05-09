using MFCLibrary.DataBase.SqlActions;
using MFCLibrary.useCases.Unique;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MFCLibrary.useCases.EmployeeUseCases
{
    internal static class DeleteEmployee
    {
        static EmployeeSql employeeSql = new EmployeeSql();
        static DelEmployeeSql delEmployeeSql = new DelEmployeeSql();

        static int deleteId = 0;
        internal static void Delete()
        {
            PrintEmployee.Print(employeeSql.TakeDataEmployee());
            while (true)
            {
                if (deleteId == 0)
                {
                    Console.Write("Введите id сотрудника: ");
                    try
                    {
                        deleteId = Convert.ToInt32(Console.ReadLine());
                    }
                    catch
                    {
                        Console.WriteLine("Неверный формат. Попробуйте ввести снова, либо вернитесь в меню: <...>");
                        if (Console.ReadLine() == "...")
                            break;
                        deleteId = 0;
                        continue;
                    }
                    if (!employeeSql.CheckEmployee("id", deleteId))
                    {
                        Console.WriteLine("Сотрудника с таким id нет в базе данных. Попробуйте ввести снова, либо вернитесь в меню: <...>");
                        deleteId = 0;
                        if (Console.ReadLine() == "...")
                            return;
                        continue;
                    }
                }
                break;
            }
            delEmployeeSql.TransferDelEmployee(deleteId);
            employeeSql.DeleteEmployee(deleteId);
            Console.WriteLine("Сотрудник удалён из базы данных\n");
        }
    }
}
