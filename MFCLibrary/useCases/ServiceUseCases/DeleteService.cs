using MFCLibrary.DataBase.SqlActions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MFCLibrary.useCases.ServiceUseCases
{
    internal static class DeleteService
    {
        static private ServiceSql serviceSql = new ServiceSql();

        static int deleteId = 0;
        internal static void Delete()
        {
            while (true)
            {
                if (deleteId == 0)
                {
                    Console.Write("Введите ID услуги: ");
                    try
                    {
                        deleteId = Convert.ToInt32(Console.ReadLine());
                    }
                    catch
                    {
                        Console.WriteLine("Неверный формат. Попробуйте ввести снова, либо вернитесь в меню: <...>");
                        deleteId = 0;
                        if (Console.ReadLine() == "...")
                            return;
                        continue;
                    }
                    if (!serviceSql.CheckService("id", deleteId))
                    {
                        Console.WriteLine("Услуги под таким номером нет в базе данных. Попробуйте ввести снова, либо вернитесь в меню: <...>");
                        deleteId = 0;
                        if (Console.ReadLine() == "...")
                            return;
                        continue;
                    }
                    if (Convert.ToBoolean(Convert.ToInt32(serviceSql.TakeValueService("isUse", "id", deleteId))))
                    {
                        Console.WriteLine("Данная услуга уже оказывалась и не может быть удалена из базы данных. Попробуйте ввести снова, либо вернитесь в меню: <...>");
                        deleteId = 0;
                        if (Console.ReadLine() == "...")
                            return;
                        continue;
                    }
                }
                break;
            }
            serviceSql.DeleteService(deleteId);
            Console.WriteLine("Услуга удалена");
            
        }
    }
}
