using MFCLibrary.Data.Models;
using MFCLibrary.DataBase.SqlActions;
using MFCLibrary.useCases.Unique;
using System;

namespace MFCLibrary.useCases.ServicesUseCases
{
    internal class AddServicing
    {
        static private ServicingSql servicingSql = new ServicingSql();
        static private ClientSql clientSql = new ClientSql();
        static private EmployeeSql employeeSql = new EmployeeSql();
        static private ServiceSql serviceSql = new ServiceSql();
        static private Servicing? servicing;

        internal static void Add()
        {
            int employeeId;
            int windowNumber;
            DateTime dateTime;
            string serviceName;
            int serviceId;
            int clientId;
            string numberQueue;

            //Получение Id сотрудника
            employeeId = ReceiveEmployeeId();
            if (employeeId == 0)
                return;

            //Получение номера окна
            windowNumber = Convert.ToInt32(employeeSql.TakeValueEmployee("windowNumber", "id", employeeId));

            //Получение текущих даты и времени
            dateTime = DateTime.Now;

            //Получение ID услуги
            serviceId = ReceiveServiceId();
            if (serviceId == 0)
                return;
            serviceName = serviceSql.TakeValueService("name", "id", serviceId);

            //Получение Id клиента
            clientId = ReceiveClientId();
            if (clientId == 0)
                return;

            //Создание номера талона
            numberQueue = CreateNumberQueue(serviceName);

            servicing = new Servicing(employeeId, Convert.ToString(windowNumber), dateTime, serviceName, clientId, numberQueue);
            servicingSql.AddServicing(servicing);
            serviceSql.UpdateService("isUse", true, serviceId);
            Console.WriteLine("Операция обслуживания была добавлена");
        }
        //Получение ID сотрудника
        private static int ReceiveEmployeeId()
        {
            int employeeId;

            while (true)
            {
                Console.WriteLine("Сотрудники:");
                PrintEmployee.PrintOrdinary(employeeSql.TakeDataEmployee());
                Console.Write("Введите id сотрудника, выполнившего обслуживание: ");
                try
                {
                    employeeId = Convert.ToInt32(Console.ReadLine());

                }
                catch
                {
                    Console.WriteLine("Неверный формат. Попробуйте ввести снова, либо вернитесь в меню: <...>");
                    if (Console.ReadLine() == "...")
                        return 0;
                    Console.Clear();
                    continue;
                }
                if (!employeeSql.CheckEmployee("id", employeeId))
                {
                    Console.WriteLine("Сотрудника с таким id нет в базе данных. Попробуйте ввести снова, либо вернитесь в меню: <...>");
                    if (Console.ReadLine() == "...")
                        return 0;
                    Console.Clear();
                    continue;
                }
                Console.Clear();
                return employeeId;
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
                PrintClient.PrintOrdinary(clientSql.TakeDataClient());
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
                Console.Clear();
                return clientId;
            }
        }
        //Создание номера талона
        private static string CreateNumberQueue(string serviceName)
        {
            string numberQueue = "";
            int num = 1;
            
            foreach (string date in servicingSql.TakeRowServicing("date"))
            {
                if (DateOnly.Parse(date) == DateOnly.FromDateTime(DateTime.Now))
                    num++;
            }
            numberQueue += serviceName[0];
            numberQueue += string.Format("{0:000}", num);
            return numberQueue;
        }
    }
}
