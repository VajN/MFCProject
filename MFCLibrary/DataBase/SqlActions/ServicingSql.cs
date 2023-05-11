using DataBase;
using MFCLibrary.Data.Models;
using MFCLibrary.DataBase.SqlActions.ServicingSqlActions;

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
