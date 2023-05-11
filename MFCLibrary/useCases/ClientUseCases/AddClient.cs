using MFCLibrary.Data.Models;
using MFCLibrary.DataBase.SqlActions;

namespace MFCLibrary.useCases.ClientUseCases
{
    internal class AddClient
    {
        static private ClientSql clientSql = new ClientSql();
        static private Client? client;

        internal static void Add(bool isAuthorized)
        {
            string fullnameClient = "";
            string passport;

            while (true)
            {
                if (fullnameClient == "")
                {
                    Console.Write("Введите ФИО клиента: ");
                    fullnameClient = Console.ReadLine();
                    continue;
                }
                Console.Write("Введите паспортные данные: ");
                passport = Console.ReadLine();
                if (passport.Length != 11)
                {
                    Console.WriteLine("Неверный формат! Попробуйте ввести снова, либо вернитесь в меню: <...>");
                    if (Console.ReadLine() == "...")
                        return;
                    continue;
                }
                if (passport[4] != ' ')
                {
                    Console.WriteLine("Неверный формат! Попробуйте ввести снова, либо вернитесь в меню: <...>");
                    if (Console.ReadLine() == "...")
                        return;
                    continue;
                }

                for (int i = 0; i < 10; i++)
                {
                    try
                    {
                        if (i != 3)
                            Convert.ToInt32(passport[i]);
                    }
                    catch
                    {
                        Console.WriteLine("Неверный формат. Попробуйте ввести снова, либо вернитесь в меню: <...>");
                        if (Console.ReadLine() == "...")
                            return;
                        continue;
                    }
                }
                if (clientSql.CheckClient("passport", passport))
                {
                    Console.WriteLine("Клиент с данными паспортными данными уже числится в базе данных. Попробуйте ввести снова, либо вернитесь в меню: <...>");
                    passport = "";
                    if (Console.ReadLine() == "...")
                        return;
                    continue;
                }
                break;
            }
            client = new Client(fullnameClient, passport);
            clientSql.AddClient(client, isAuthorized);
            Console.WriteLine("Клиент добавлен в базу данных\n");
        }
    }
}
