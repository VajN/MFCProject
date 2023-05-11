using DataBase;
using MFCLibrary.Data.Models;
using MFCLibrary.DataBase.SqlActions.ClientSqlActions;

namespace MFCLibrary.DataBase.SqlActions
{
    internal class ClientSql
    {
        MFCDataBase db { get; } = new MFCDataBase();

        internal void AddClient(Client client, bool isAuthorized)
        {
            SqlAddClient.AddClient(db, client, isAuthorized);
        }
        internal void UpdateClient(string updateRow, object newValue, int id)
        {
            SqlUpdateClient.UpdateClient(db, updateRow, newValue, id);
        }
        internal List<string[]> TakeDataClient()
        {
            return SqlTakeDataClient.TakeDataClient(db);
        }
        internal string TakeValueClient(string row, string checkRow, object checkValue)
        {
            return SqlTakeValueClient.TakeValueClient(db, row, checkRow, checkValue);
        }
        internal bool CheckClient(string checkRow, object checkValue)
        {
            return SqlCheckClient.CheckClient(db, checkRow, checkValue);
        }
    }
}
