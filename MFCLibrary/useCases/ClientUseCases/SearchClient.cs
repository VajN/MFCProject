
using MFCLibrary.DataBase.SqlActions;
using MFCLibrary.useCases.EmployeeUseCases;
using MFCLibrary.useCases.Unique;

namespace MFCLibrary.useCases.ClientUseCases
{
    internal class SearchClient
    {
        static ClientSql clientSql = new ClientSql();
        static AuthorizedServicingSql authorizedServicingSql = new AuthorizedServicingSql();
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
                    Console.Clear();
                }
                if (criteria == "1")
                {
                    Console.Write("Введите ФИО клиента: ");
                    search = Console.ReadLine();

                    if (!clientSql.CheckClient("fullnameClient", search))
                    {
                        Console.WriteLine("Клиента с таким ФИО нет в базе данных. Попробуйте ввести снова, либо вернитесь в меню: <...>");
                        search = "";
                        if (Console.ReadLine() == "...")
                            return;
                        Console.Clear();
                        continue;
                    }
                    if (search == "")
                    {
                        Console.WriteLine("Необходимо ввести ФИО клиента. Попробуйте ввести снова, либо вернитесь в меню: <...>");
                        if (Console.ReadLine() == "...")
                            return;
                        Console.Clear();
                        continue;
                    }
                    Console.Clear();
                    clientId = Convert.ToInt32(clientSql.TakeValueClient("id", "fullnameClient", search));
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
                        Console.Clear();
                        continue;
                    }
                    if (search == "")
                    {
                        Console.WriteLine("Необходимо ввести паспортные данные клиента. Попробуйте ввести снова, либо вернитесь в меню: <...>");
                        if (Console.ReadLine() == "...")
                            return;
                        Console.Clear();
                        continue;
                    }
                    Console.Clear();
                    clientId = Convert.ToInt32(clientSql.TakeValueClient("id", "passport", search));
                    Console.Clear();
                }
                Console.WriteLine("Данные клиента:");
                PrintClient.PrintById(clientSql.TakeDataClient(), clientId);
                Console.WriteLine("Оказанные услуги: ");
                if (!Convert.ToBoolean(clientSql.TakeValueClient("isAuthorized", "id", clientId)))
                    PrintServicing.Print(servicingSql.TakeDataServicing(), "clientId", clientId);
                else
                    PrintAutorizedServicing.Print(authorizedServicingSql.TakeDataAuthorizedServicing(), "clientId", clientId);
                break;
            }
        }
    }
}
