using MFCLibrary.DataBase.SqlActions;
using MFCLibrary.Models;

namespace MFCLibrary.useCases.ServicesUseCases
{
    internal class AddServicing
    {
        static private ServicingSql servicingSql = new ServicingSql();
        static private ClientSql clientSql = new ClientSql();
        static private EmployeeSql employeeSql = new EmployeeSql();
        static private ServiceSql serviceSql = new ServiceSql();
        static private Servicing? servicing;
        static internal int employeeId { get; private set; } = 0;
        static internal int windowNumber { get; private set; } = 0;
        static internal DateTime dateTime { get; private set; } = new DateTime();
        static internal string serviceName { get; private set; } = "";
        static internal int serviceId { get; private set; } = 0;
        static internal int clientId { get; private set; } = 0;
        static internal string numberQueue { get; private set; } = "";
        static private int num = 1;

        internal static void Add()
        {
            while (true)
            {
                //Получение Id сотрудника
                if (employeeId == 0)
                {
                    Console.Write("Введите id сотрудника, выполнившего обслуживание: ");
                    try
                    {
                        employeeId = Convert.ToInt32(Console.ReadLine());

                    }
                    catch
                    {
                        Console.WriteLine("Неверный формат. Попробуйте ввести снова, либо вернитесь в меню: <...>");
                        if (Console.ReadLine() == "...")
                            return;
                        continue;
                    }
                    if (!employeeSql.CheckEmployee("id", employeeId))
                    {
                        Console.WriteLine("Сотрудника с таким id нет в базе данных. Попробуйте ввести снова, либо вернитесь в меню: <...>");
                        employeeId = 0;
                        if (Console.ReadLine() == "...")
                            return;
                        continue;
                    }
                }
                //Получение номера окна
                windowNumber = Convert.ToInt32(employeeSql.TakeValueEmployee("windowNumber", "id", employeeId));
                //Получение текущих даты и времени
                dateTime = DateTime.Now;
                //Получение ID услуги
                if (serviceId == 0)
                {
                    Console.Write("Введите ID необходимой услуги: ");
                    serviceId = Convert.ToInt32(Console.ReadLine());
                    if (!serviceSql.CheckService("id", serviceId))
                    {
                        Console.WriteLine("Услуги с таким ID нет в базе данных. Попробуйте ввести снова, либо вернитесь в меню: <...>");
                        serviceId = 0;
                        if (Console.ReadLine() == "...")
                            return;
                        continue;
                    }
                    serviceName = serviceSql.TakeValueService("name", "id", serviceId);
                }
                //Получение Id клиента
                if (clientId == 0)
                {
                    Console.Write("Введите id клиента, которому была предоставлена услуга: ");
                    clientId = Convert.ToInt32(Console.ReadLine());
                    if (!clientSql.CheckClient("id", clientId))
                    {
                        Console.WriteLine("Клиента с таким id нет в базе данных. Попробуйте ввести снова, либо вернитесь в меню: <...>");
                        clientId = 0;
                        if (Console.ReadLine() == "...")
                            return;
                        continue;
                    }
                }
                //Создание номера талона
                foreach (string date in servicingSql.TakeRowServicing("date"))
                {
                    if (DateOnly.Parse(date) == DateOnly.FromDateTime(DateTime.Now))
                        num++;
                }
                numberQueue += serviceName[0];
                numberQueue += string.Format("{0:000}", num);
                break;
            }
            servicing = new Servicing(employeeId, windowNumber, dateTime, serviceName, clientId, numberQueue);
            servicingSql.AddServicing(servicing);
            serviceSql.UpdateService("isUse", true, serviceId);
            Console.WriteLine("Операция обслуживания была добавлена");
        }
    }
}
