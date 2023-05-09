using MFCLibrary.useCases.ClientUseCases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MFCLibrary.Menu.Second
{
    internal static class MenuAddClient
    {
        internal static void Menu()
        {
            string temp = "";

            Console.WriteLine("Типы регистрации клиентов:\n1.Обычная\n2.Через ГосУслуги\n");
            while (true)
            {
                Console.Write("Выберите тип: ");
                temp = Console.ReadLine();
                if (temp == "1")
                {
                    Console.Clear();
                    AddClient.Add(false);
                }
                else if (temp == "2")
                {
                    Console.Clear();
                    AddClient.Add(true);
                }
                else
                {
                    Console.WriteLine("Необходимо выбрать тип регистрации клиента. Попробуйте ввести снова, либо вернитесь в меню: <...>");
                    if (Console.ReadLine() == "...")
                        return;
                    continue;
                }
                break;
            }
        }
    }
}
