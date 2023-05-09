
using MFCLibrary.DataBase.SqlActions;
using MFCLibrary.useCases.EmployeeUseCases;
using MFCLibrary.useCases.Unique;

namespace MFCLibrary.useCases.ClientUseCases
{
    internal class SearchClient
    {
        static ClientSql clientSql = new ClientSql();
        static ServicingSql servicingSql = new ServicingSql();

        public static void Search()
        {
            string criteria = "";
            string search = "";
            int clientId = 0;

            while (true)
            {
                if (criteria == "")
                {
                    Console.WriteLine("Критерии поиска клиента:\n1.ФИО\n2.Паспортные данные: ");
                    Console.Write("\nКритерий: ");
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

                    clientId = Convert.ToInt32(clientSql.TakeValueClient("id", "fullnameClient", search));
                    Console.Clear();
                    Console.WriteLine("Данные клиента:");
                    PrintClient.Print(clientSql.TakeDataClient(), clientId);

                    Console.WriteLine("Оказанные услуги: ");
                    PrintServicing.Print(servicingSql.TakeDataServicing(), "clientId", clientId);
                }
                if (criteria == "2")
                {
                    Console.Write("Введите паспортные данные клиента: ");
                    search = Console.ReadLine();
                    if (!clientSql.CheckClient("passport", search))
                    {
                        Console.WriteLine("Клиента с такими паспортными данными нет в базе данных. Попробуйте ввести снова, либо вернитесь в меню: <...>");
                        search = "";
                        if (Console.ReadLine() == "...")
                            return;
                        continue;
                    }
                    if (search == "")
                    {
                        Console.WriteLine("Необходимо ввести паспортные данные клиента. Попробуйте ввести снова, либо вернитесь в меню: <...>");
                        if (Console.ReadLine() == "...")
                            return;
                        continue;
                    }
                    clientId = Convert.ToInt32(clientSql.TakeValueClient("id", "passport", search));
                    Console.Clear();
                    Console.WriteLine("Данные клиента:");
                    PrintClient.Print(clientSql.TakeDataClient(), clientId);
                    Console.WriteLine("Оказанные услуги: ");
                    PrintServicing.Print(servicingSql.TakeDataServicing(), "clientId", clientId);
                }
                break;
            }
        }
    }
}
