using MFCLibrary.Data.Models;
using MFCLibrary.DataBase.SqlActions;
using MFCLibrary.useCases.Unique;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MFCLibrary.useCases.AuthorizedServicingUseCases
{
    internal static class AddAuthorizedServicing
    {
        static AuthorizedServicingSql authorizedServicingSql = new AuthorizedServicingSql();
        static EmployeeSql employeeSql = new EmployeeSql();
        static ServiceSql serviceSql = new ServiceSql();
        static ClientSql clientSql = new ClientSql();

        internal static void Add()
        {
            int employeeId;
            string windowNumber;
            DateOnly date;
            TimeOnly time;
            string serviceName;
            int serviceId;
            int clientId;

            while (true)
            {
                //Получение номера окна обслуживания
                windowNumber = ReceiveWindowNumber();
                if (windowNumber == "")
                    return;

                //Получение ID сотрудника
                employeeId = Convert.ToInt32(employeeSql.TakeValueEmployee("id", "windowNumber", windowNumber));

                //Получение текущих даты и времени
                date = DateOnly.FromDateTime(DateTime.Now);
                time = ReceiveTime();
                if (Convert.ToString(time) == "0:00")
                    return;
                //Получение ID услуги

                serviceId = ReceiveServiceId();
                if (serviceId == 0)
                    return;
                serviceName = serviceSql.TakeValueService("name", "id", serviceId);

                //Получение Id клиента
                clientId = ReceiveClientId();
                if (clientId == 0)
                    return;
                break;
            }
            AuthorizedServicing authorizedServicing = new AuthorizedServicing(employeeId, windowNumber, DateTime.Parse($"{date} {time}"), serviceName, clientId);
            authorizedServicingSql.AddAuthorizedServicing(authorizedServicing);
            serviceSql.UpdateService("isUse", true, serviceId);
            Console.WriteLine("Операция обслуживания была добавлена");
        }


        //Получение номера окна обслуживания
        private static string ReceiveWindowNumber()
        {
            string windowNumber;

            while (true)
            {
                Console.Write("Введите номер окна обслуживания(формат Г**, где * - номер окна обслуживания): ");
                windowNumber = Console.ReadLine();
                try
                {
                    if (char.IsDigit(windowNumber[0]))
                    {
                        Console.WriteLine("Неверный формат. Попробуйте ввести снова, либо вернитесь в меню: <...>");
                        if (Console.ReadLine() == "...")
                            return "";
                        Console.Clear();
                        continue;
                    }
                }
                catch
                {
                    Console.WriteLine("Неверный формат. Попробуйте ввести снова, либо вернитесь в меню: <...>");
                    if (Console.ReadLine() == "...")
                        return "";
                    Console.Clear();
                    continue;
                }
                if (!employeeSql.CheckEmployee("windowNumber", windowNumber))
                {
                    Console.WriteLine("Сотрудника с таким номером окна обслуживания нет в базе данных. Попробуйте ввести снова, либо вернитесь в меню: <...>");
                    if (Console.ReadLine() == "...")
                        return "";
                    Console.Clear();
                    continue;
                }
                Console.Clear();
                return windowNumber;
            }
        }
        //Получение ID услуги
        private static int ReceiveServiceId()
        {
            int serviceId;

            while (true)
            {
                Console.WriteLine("Услуги: ");
                PrintService.Print(serviceSql.TakeDataService());
                Console.Write("Введите ID необходимой услуги: ");
                try
                {
                    serviceId = Convert.ToInt32(Console.ReadLine());
                }
                catch
                {
                    Console.WriteLine("Неверный формат. Попробуйте ввести снова, либо вернитесь в меню: <...>");
                    if (Console.ReadLine() == "...")
                        return 0;
                    Console.Clear();
                    continue;
                }
                if (!serviceSql.CheckService("id", serviceId))
                {
                    Console.WriteLine("Услуги с таким ID нет в базе данных. Попробуйте ввести снова, либо вернитесь в меню: <...>");
                    if (Console.ReadLine() == "...")
                        return 0;
                    Console.Clear();
                    continue;
                }
                Console.Clear();
                return serviceId;
            }
        }
        //Получение ID клиента
        private static int ReceiveClientId()
        {
            int clientId;

            while (true)
            {
                Console.WriteLine("Клиенты: ");
                PrintClient.PrintSpecial(clientSql.TakeDataClient());
                Console.Write("Введите id клиента, которому была предоставлена услуга: ");
                try
                {
                    clientId = Convert.ToInt32(Console.ReadLine());
                }
                catch
                {
                    Console.WriteLine("Неверный формат. Попробуйте ввести снова, либо вернитесь в меню: <...>");
                    if (Console.ReadLine() == "...")
                        return 0;
                    Console.Clear();
                    continue;
                }
                if (!clientSql.CheckClient("id", clientId))
                {
                    Console.WriteLine("Клиента с таким id нет в базе данных. Попробуйте ввести снова, либо вернитесь в меню: <...>");
                    if (Console.ReadLine() == "...")
                        return 0;
                    Console.Clear();
                    continue;
                }
                if (!Convert.ToBoolean(clientSql.TakeValueClient("isAuthorized", "id", clientId)))
                {
                    Console.WriteLine("Данный клиент не был зарегистрирован через ГосУслуги. Попробуйте ввести снова, либо вернитесь в меню: <...>");
                    if (Console.ReadLine() == "...")
                        return 0;
                    Console.Clear();
                    continue;
                }
                Console.Clear();
                return clientId;
            }
        }
        private static TimeOnly ReceiveTime()
        {
            TimeOnly time;

            while (true)
            {
                Console.WriteLine("Введите назначенное время (Время приёма от 9:00 до 19:00, с промежутком в 15 минут): ");
                Console.Write("Время: ");
                try
                {
                    time = TimeOnly.Parse(Console.ReadLine());
                }
                catch
                {
                    Console.WriteLine("Неверный формат. Попробуйте ввести снова, либо вернитесь в меню: <...>");
                    if (Console.ReadLine() == "...")
                        return TimeOnly.Parse("0:00");
                    Console.Clear();
                    continue;

                }
                if (time.Hour < 9 || time.Hour > 19)
                {
                    Console.WriteLine("Необходимо ввести время в промежутке от 9:00 до 19:00. Попробуйте ввести снова, либо вернитесь в меню: <...>");
                    if (Console.ReadLine() == "...")
                        return TimeOnly.Parse("0:00");
                    Console.Clear();
                    continue;
                }
                if (time.Minute % 15 != 0)
                {
                    Console.WriteLine("Необходимо ввести время с интервалом в 15 минут. Попробуйте ввести снова, либо вернитесь в меню: <...>");
                    if (Console.ReadLine() == "...")
                        return TimeOnly.Parse("0:00");
                    Console.Clear();
                    continue;
                }
                if(authorizedServicingSql.CheckAuthorizedServicing("date", Convert.ToString(DateOnly.FromDateTime(DateTime.Now))))
                {
                    if(authorizedServicingSql.CheckAuthorizedServicing("time", Convert.ToString(time)))
                    {
                        Console.WriteLine("Данное время уже занято другой операцией обслуживания. Попробуйте ввести снова, либо вернитесь в меню: <...>");
                        if (Console.ReadLine() == "...")
                            return TimeOnly.Parse("0:00");
                        Console.Clear();
                        continue;
                    }
                }
                Console.Clear();
                return time;
            }
        }
    }
}
