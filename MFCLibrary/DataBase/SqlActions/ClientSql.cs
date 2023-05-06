using DataBase;
using MFCLibrary.Models;
using System.Data.SQLite;

namespace MFCLibrary.DataBase.SqlActions
{
    internal class ClientSql
    {
        MFCDataBase db { get; } = new MFCDataBase();
        internal void AddClient(Client client)
        {
            db.command.CommandText = $"INSERT INTO {db.ClientTableName} (fullnameClient, passport) VALUES (\"{client.fullnameClient}\",\"{client.passport}\")";
            db.command.ExecuteNonQuery();
        }
        internal bool CheckClient(string passport)
        {
            db.command.CommandText = $"SELECT passport FROM {db.ClientTableName}";
            SQLiteDataReader reader = db.command.ExecuteReader();
            while (reader.Read())
            {
                if (reader.GetString(0) == passport)
                {
                    reader.Close();
                    return true;
                }
            }
            reader.Close();
            return false;
        }
    }
}
