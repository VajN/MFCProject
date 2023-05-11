namespace MFCLibrary.Data.Models
{
    internal class Employee
    {
        internal string fullnameEmployee { get; private set; } = "";
        internal DateOnly birthday { get; private set; } = new DateOnly();
        internal string windowNumber { get; private set; } = "";
        internal Employee(string fullnameEmployee, DateOnly birthday, string windowNumber)
        {
            this.fullnameEmployee = fullnameEmployee;
            this.birthday = birthday;
            this.windowNumber = windowNumber;
        }
    }
}
