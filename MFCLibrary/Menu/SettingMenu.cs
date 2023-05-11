using MFCLibrary.Menu.Second;
namespace MFCLibrary.Menu
{
    internal static class SettingMenu
    {
        static string? temp;
        internal static void Settings()
        {
            Console.WriteLine("Настройки.");
            while (true)
            {
                Console.WriteLine("1. Сменить тему\n" +
                "2. В разработке...\n" +
                "0. Назад");
                Console.Write("Выбор действия: ");
                temp = Console.ReadLine();
                switch (temp)
                {
                    case "0":
                        Console.Clear();
                        MainMenu.Menu();
                        break;
                    case "1":
                        Console.Clear();
                        MenuSettingsThemes.ChangeThemes();
                        break;
                    case "2":
                        Console.Clear();
                        MainMenu.Menu();
                        break;
                }
                if (temp != "")
                    Console.Read();
                Console.Clear();
            }            
        }
    }
}
