using DataBase;
using MFCLibrary.Models;

namespace MFCLibrary.DataBase.SqlActions.ClientSqlActions
{
    internal static class SqlAddClient
    {
        internal static void AddClient(MFCDataBase db, Client client, bool isAuthorized )
        {
            db.command.CommandText = $"INSERT INTO {db.ClientTableName} (fullnameClient, passport, isAuthorized ) VALUES (\"{client.fullnameClient}\",\"{client.passport}\", {isAuthorized})";
            db.command.ExecuteNonQuery();
        }
    }
}
