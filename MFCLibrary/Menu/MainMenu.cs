using MFCLibrary.Menu.Second;
using MFCLibrary.useCases.ClientUseCases;
using MFCLibrary.useCases.EmployeeUseCases;
using MFCLibrary.useCases.ServicesUseCases;
using MFCLibrary.useCases.ServiceUseCases;
using MFCLibrary.useCases.ServicingUseCases;

namespace MFCLibrary.Menu
{
    public static class MainMenu
    {
        static string? temp;
        public static void Menu()
        {
            Console.WriteLine("Приветствуем вас в меню базы данных отделения МФЦ.");
            while (true)
            {
                Console.WriteLine("1. Добавить нового сотрудника\n" +
                "2. Добавить нового клиента\n" +
                "3. Добавить услугу\n" +
                "4. Добавить информацию об обслуживании клиентов\n" +
                "5. Редактировать данные о сотруднике\n" +
                "6. Редактировать данные о клиенте\n" +
                "7. Поиск клиента\n" +
                "8. Поиск операции обслуживания\n" +
                "9. Просмотр статистики обслуживания\n" +
                "10. Удаление сотрудника из базы\n" +
                "11. Удаление услуги\n" +
                "12. Настройки");
                Console.Write("Выбор действия: ");
                temp = Console.ReadLine();
                switch (temp)
                {
                    case "1":
                        Console.Clear();
                        AddEmployee.Add();
                        break;
                    case "2":
                        Console.Clear();
                        MenuAddClient.Menu();
                        break;
                    case "3":
                        Console.Clear();
                        AddService.Add();
                        break;
                    case "4":
                        Console.Clear();
                        MenuAddServicing.Menu();
                        break;
                    case "5":
                        Console.Clear();
                        ChangeEmployee.Change();
                        break;
                    case "6":
                        Console.Clear();
                        ChangeClient.Change();
                        break;
                    case "7":
                        Console.Clear();
                        SearchClient.Search();
                        break;
                    case "8":
                        Console.Clear();
                        SearchServicing.Search();
                        break;
                    case "9":
                        Console.Clear();
                        ViewServicingStatistics.ServicingStatistics();
                        break;
                    case "10":
                        Console.Clear();
                        DeleteEmployee.Delete();
                        break;
                    case "11":
                        Console.Clear();
                        DeleteService.Delete();
                        break;
                    case "12":
                        Console.Clear();
                        SettingMenu.Settings();
                        break;
                }
                if (temp != "")
                    Console.Read();
                Console.Clear();
            }
        }
    }
}
