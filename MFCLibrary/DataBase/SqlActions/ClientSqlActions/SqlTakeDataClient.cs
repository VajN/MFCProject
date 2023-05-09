using DataBase;
using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MFCLibrary.DataBase.SqlActions.ClientSqlActions
{
    internal static class SqlTakeDataClient
    {
        internal static List<string[]> TakeDataClient(MFCDataBase db)
        {
            List<string[]> result = new List<string[]>();
            string temp = "";

            db.command = new SQLiteCommand($"SELECT * FROM {db.ClientTableName}", db.connection);
            SQLiteDataReader reader = db.command.ExecuteReader();

            while (reader.Read())
            {
                try
                {
                    for (int i = 0; true; i++)
                        temp += $"{reader.GetValue(i)}/";
                }
                catch
                {
                    result.Add(temp.Split("/"));
                    temp = "";
                }
            }
            reader.Close();
            return result;
        }
    }
}
