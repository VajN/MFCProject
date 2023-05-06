using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Authentication.ExtendedProtection;
using System.Text;
using System.Threading.Tasks;

namespace MFCLibrary.Models
{
    internal class Servicing
    {
        internal int employeeId { get; private set; } = 0;
        internal int windowNumber { get; private set; } = 0;
        internal DateTime dateTime { get; private set; } = new DateTime();
        internal string serviceName { get; private set; } = "";
        internal int clientId { get; private set; } = 0;
        internal string numberQueue { get; private set; } = "";
        internal Servicing(int employeeId, int windowNumber, DateTime dateTime, 
            string serviceName, int clientId, string numberQueue)
        {
            this.employeeId = employeeId;
            this.windowNumber = windowNumber;
            this.dateTime = dateTime;
            this.serviceName = serviceName;
            this.clientId = clientId;
            this.numberQueue = numberQueue;
        }
    }
}
