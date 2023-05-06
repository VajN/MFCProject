using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataBase.Entities
{
    internal class Servicing
    {
        internal int employeeId { get; private set; } = 0;
        internal int windowNumber { get; private set; } = 0;
        internal DateTime dateTime { get; private set; } = new DateTime();
        internal string serviceName { get; private set; } = "";
        internal int clientId { get; private set; } = 0;
        internal string numberQueue { get; private set; } = "";
    }
}
