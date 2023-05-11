
namespace MFCLibrary.Data
{
    internal static class Themes
    {
        private static ConsoleColor[] colors = (ConsoleColor[])ConsoleColor.GetValues(typeof(ConsoleColor));

        internal static List<ConsoleColor> theme0 = new List<ConsoleColor>() { colors[0], colors[15] };
        internal static List<ConsoleColor> theme1 = new List<ConsoleColor>() { colors[10], colors[15] };
        internal static List<ConsoleColor> theme2 = new List<ConsoleColor>() { colors[2], colors[9] };
        internal static List<ConsoleColor> theme3 = new List<ConsoleColor>() { colors[6], colors[1] };
    }
}
