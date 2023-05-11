using MFCLibrary.Data;
using MFCLibrary.Settings;

namespace MFCLibrary.Menu.Second
{
    internal class MenuSettingsThemes
    {
        static string? temp;
        internal static void ChangeThemes()
        {
            Console.WriteLine("Настройки, выбор темы.");
            while (true)
            {
                Console.WriteLine("1. Стандартная(Ч/Б)\n" +
                "2. Токсичная(З/Б)\n" +
                "3. Токсичная2(ТЗ/С)\n" +
                "4. Поддержка украины(ТЖ/ТС)\n" +
                "0. Назад");
                Console.Write("Выбор действия: ");
                temp = Console.ReadLine();
                switch (temp)
                {
                    case "0":
                        Console.Clear();
                        SettingMenu.Settings();
                        break;
                    case "1":
                        Console.Clear();
                        ChangeTheme.Theme(Themes.theme0);
                        break;
                    case "2":
                        Console.Clear();
                        ChangeTheme.Theme(Themes.theme1);
                        break;
                    case "3":
                        Console.Clear();
                        ChangeTheme.Theme(Themes.theme2);
                        break;
                    case "4":
                        Console.Clear();
                        ChangeTheme.Theme(Themes.theme3);
                        break;
                }
                if (temp != "")
                    Console.Read();
                Console.Clear();
            }
        }
    }
}
