using MFCLibrary.DataBase.SqlActions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MFCLibrary.useCases.Unique
{
    internal static class PrintEmployee
    {
        internal static void Print(List<string[]> lists)
        {
            foreach (string[] list in lists)
            {
                Console.WriteLine($"ID: {list[0]}| ФИО: {list[1]}| День рождения: {list[2]}| Окно обслуживания: {list[3]}");
                Console.WriteLine("==========================================");
            }
        }
    }
}
