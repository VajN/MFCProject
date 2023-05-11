using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MFCLibrary.Data.Models
{
    internal class AuthorizedServicing
    {
        internal int employeeId { get; private set; } = 0;
        internal string windowNumber { get; private set; } = "";
        internal DateTime dateTime { get; private set; } = new DateTime();
        internal string serviceName { get; private set; } = "";
        internal int clientId { get; private set; } = 0;
        internal AuthorizedServicing(int employeeId, string windowNumber, DateTime dateTime,
            string serviceName, int clientId)
        {
            this.employeeId = employeeId;
            this.windowNumber = windowNumber;
            this.dateTime = dateTime;
            this.serviceName = serviceName;
            this.clientId = clientId;
        }
    }
}
