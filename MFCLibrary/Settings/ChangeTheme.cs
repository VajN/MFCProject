
namespace MFCLibrary.Settings
{
    internal class ChangeTheme
    {
        internal static void Theme(List<ConsoleColor> theme)
        {
            Console.BackgroundColor = theme[0];
            Console.ForegroundColor = theme[1];
            Console.Clear();
        }
    }
}
