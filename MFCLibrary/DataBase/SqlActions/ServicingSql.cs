using DataBase;
using MFCLibrary.DataBase.SqlActions.ServicingSqlActions;
using MFCLibrary.Models;

namespace MFCLibrary.DataBase.SqlActions
{
    internal class ServicingSql
    {
        MFCDataBase db { get; } = new MFCDataBase();

        internal void AddServicing(Servicing servicing)
        {
            SqlAddServicing.AddServicing(db, servicing);
        }
        internal List<string[]> TakeDataServicing()
        {
            return SqlTakeDataServicing.TakeDataServicing(db);
        }
        internal List<string> TakeRowServicing(string row)
        {
            return SqlTakeRowServicing.TakeRowServicing(db, row);
        }
    }
}
