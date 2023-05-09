using MFCLibrary.DataBase.SqlActions;
using MFCLibrary.useCases.Unique;

namespace MFCLibrary.useCases.ServiceUseCases
{
    internal static class DeleteService
    {
        static private ServiceSql serviceSql = new ServiceSql();

        internal static void Delete()
        {
            int deleteId = 0;

            PrintService.Print(serviceSql.TakeDataService());
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
                    if (Convert.ToBoolean(serviceSql.TakeValueService("isUse", "id", deleteId)))
                    {
                        Console.WriteLine("Данная услуга уже оказывалась и не может быть удалена из базы данных. Попробуйте ввести снова, либо вернитесь в меню: <...>");
                        deleteId = 0;
                        if (Console.ReadLine() == "...")
                            return;
                        continue;
                    }
                }
                serviceSql.DeleteService(deleteId);
                Console.WriteLine("Услуга удалена");
                break;
            }
        }
    }
}
