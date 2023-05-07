namespace MFCLibrary.Models
{
    internal class Employee
    {
        internal string fullnameEmployee { get; private set; } = "";
        internal DateOnly birthday { get; private set; } = new DateOnly();
        internal int windowNumber { get; private set; } = 0;
        internal Employee(string fullnameEmployee, DateOnly birthday, int windowNumber) 
        {
            this.fullnameEmployee = fullnameEmployee;
            this.birthday = birthday;
            this.windowNumber = windowNumber;
        }
    }
}
