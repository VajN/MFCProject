using MFCLibrary.DataBase.SqlActions;
using MFCLibrary.useCases.EmployeeUseCases;
using MFCLibrary.useCases.Unique;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MFCLibrary.useCases.ClientUseCases
{
    internal static class ChangeClient
    {
        static ClientSql clientSql = new ClientSql();

        public static void Change()
        {
            int changeId = 0;
            string newPassport = "";

            while (true)
            {
                if (changeId == 0)
                {
                    Console.WriteLine("Клиенты: ");
                    PrintClient.PrintAll(clientSql.TakeDataClient());
                    Console.Write("Введите id клиента: ");
                    try
                    {
                        changeId = Convert.ToInt32(Console.ReadLine());
                    }
                    catch
                    {
                        Console.WriteLine("Неверный формат. Попробуйте ввести снова, либо вернитесь в меню: <...>");
                        changeId = 0;
                        if (Console.ReadLine() == "...")
                            return;
                        Console.Clear();
                        continue;
                    }
                    if (!clientSql.CheckClient("id", changeId))
                    {
                        Console.WriteLine("Клиента с таким id нет в базе данных. Попробуйте ввести снова, либо вернитесь в меню: <...>");
                        changeId = 0;
                        if (Console.ReadLine() == "...")
                            return;
                        Console.Clear();
                        continue;
                    }
                    Console.Clear();
                }
                if(newPassport == "")
                {
                    Console.Write("Введите новые паспортные данные: ");
                    newPassport = Console.ReadLine();
                    if (newPassport.Length != 11)
                    {
                        Console.WriteLine("Неверный формат. Попробуйте ввести снова, либо вернитесь в меню: <...>");
                        newPassport = "";
                        if (Console.ReadLine() == "...")
                            return;
                        Console.Clear();
                        continue;
                    }
                    if (newPassport[4] != ' ')
                    {
                        Console.WriteLine("Неверный формат. Попробуйте ввести снова, либо вернитесь в меню: <...>");
                        newPassport = "";
                        if (Console.ReadLine() == "...")
                            return;
                        Console.Clear();
                        continue;
                    }

                    for (int i = 0; i < 10; i++)
                    {
                        try
                        {
                            if (i != 3)
                                Convert.ToInt32(newPassport[i]);
                        }
                        catch
                        {
                            Console.WriteLine("Неверный формат. Попробуйте ввести снова, либо вернитесь в меню: <...>");
                            newPassport = "";
                            if (Console.ReadLine() == "...")
                                return;
                            Console.Clear();
                            continue;
                        }
                    }
                    if (clientSql.CheckClient("passport", newPassport))
                    {
                        Console.WriteLine("Клиент с такими паспортными данными уже присутствует в базе данных. Попробуйте ввести снова, либо вернитесь в меню: <...>");
                        newPassport = "";
                        if (Console.ReadLine() == "...")
                            return;
                        Console.Clear();
                        continue;
                    }
                }
                clientSql.UpdateClient("passport", newPassport, changeId);
                Console.WriteLine("Данные клиента изменены\n");
                break;
            }
        }
    }
}
