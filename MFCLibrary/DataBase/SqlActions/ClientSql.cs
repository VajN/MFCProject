using DataBase;
using MFCLibrary.DataBase.SqlActions.ClientSqlActions;
using MFCLibrary.Models;
using System.Data.SQLite;

namespace MFCLibrary.DataBase.SqlActions
{
    internal class ClientSql
    {
        MFCDataBase db { get; } = new MFCDataBase();
        internal void AddClient(Client client)
        {
            SqlAddClient.AddClient(db, client);
        }

        internal bool CheckClient(string checkRow, object checkValue)
        {
            return SqlCheckClient.CheckClient(db, checkRow, checkValue);
        }
    }
}
