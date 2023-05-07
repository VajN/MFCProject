using MFCLibrary.useCases.ClientUseCases;
using MFCLibrary.useCases.EmployeeUseCases;
using MFCLibrary.useCases.ServicesUseCases;
using MFCLibrary.useCases.ServiceUseCases;

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
                "11. Удаление услуги\n");
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
                        AddClient.Add();
                        break;
                    case "3":
                        Console.Clear();
                        AddService.Add();
                        break;
                    case "4":
                        Console.Clear();
                        AddServicing.Add();
                        break;
                    case "11":
                        Console.Clear();
                        DeleteService.Delete();
                        break;
                }
                if (temp != "")
                    Console.Read();
                Console.Clear();
            }
        }
    }
}
