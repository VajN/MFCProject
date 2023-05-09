using MFCLibrary.useCases.AuthorizedServicingUseCases;
using MFCLibrary.useCases.ClientUseCases;
using MFCLibrary.useCases.ServicesUseCases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MFCLibrary.Menu.Second
{
    internal class MenuAddServicing
    {
        internal static void Menu()
        {
            string temp = "";

            Console.WriteLine("Типы регистрации клиентов, которым может быть оказана услуга:\n1.Обычная\n2.Через ГосУслуги\n");
            while (true)
            {
                Console.Write("Выберите тип: ");
                temp = Console.ReadLine();
                if (temp == "1")
                {
                    Console.Clear();
                    AddServicing.Add();
                }
                else if (temp == "2")
                {
                    Console.Clear();
                    AddAuthorizedServicing.Add();
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
