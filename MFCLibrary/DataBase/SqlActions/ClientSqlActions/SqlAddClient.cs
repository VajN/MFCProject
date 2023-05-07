using DataBase;
using MFCLibrary.Models;

namespace MFCLibrary.DataBase.SqlActions.ClientSqlActions
{
    internal static class SqlAddClient
    {
        internal static void AddClient(MFCDataBase db, Client client)
        {
            db.command.CommandText = $"INSERT INTO {db.ClientTableName} (fullnameClient, passport) VALUES (\"{client.fullnameClient}\",\"{client.passport}\")";
            db.command.ExecuteNonQuery();
        }
    }
}
