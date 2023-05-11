namespace MFCLibrary.Data.Models
{
    internal class Service
    {
        internal string name { get; private set; } = "";
        internal Service(string name)
        {
            this.name = name;
        }
    }
}
