using MFCLibrary.DataBase.SqlActions;
using MFCLibrary.DataBase;
using DataBase;
using MFCLibrary.Data.Models;

namespace MFCLibrary.useCases.ServiceUseCases
{
    internal class AddService
    {
        static private ServiceSql serviceSql { get; } = new ServiceSql();
        static private Service? service;

        internal static void Add()
        {
            string name = "";

            while (true)
            {
                Console.Write("Введите название услуги: ");
                name = Console.ReadLine();
                if (name is null || name == "")
                {
                    Console.WriteLine("Необходимо название. Попробуйте ввести снова, либо вернитесь в меню: <...>");
                    if (Console.ReadLine() == "...")
                        return;
                    continue;
                }
                break;
            }
            service = new Service(name);
            serviceSql.AddService(service);
            Console.WriteLine("Услуга добавлена в базу данных\n");
            
        }
    }
}
