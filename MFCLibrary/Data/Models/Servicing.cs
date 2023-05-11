namespace MFCLibrary.Data.Models
{
    internal class Servicing
    {
        internal int employeeId { get; private set; } = 0;
        internal string windowNumber { get; private set; } = "";
        internal DateTime dateTime { get; private set; } = new DateTime();
        internal string serviceName { get; private set; } = "";
        internal int clientId { get; private set; } = 0;
        internal string numberQueue { get; private set; } = "";
        internal Servicing(int employeeId, string windowNumber, DateTime dateTime,
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
