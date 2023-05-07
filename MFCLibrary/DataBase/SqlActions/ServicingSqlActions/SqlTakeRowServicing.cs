using DataBase;
using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MFCLibrary.DataBase.SqlActions.ServicingSqlActions
{
    internal static class SqlTakeRowServicing
    {
        static List<string> result = new List<string>();
        internal static List<string> TakeRowServicing(MFCDataBase db, string row)
        {
            db.command = new SQLiteCommand($"SELECT {row} FROM {db.ServicingTableName}", db.connection);
            SQLiteDataReader reader = db.command.ExecuteReader();
            while (reader.Read())
            {
                result.Add(reader.GetString(0));
            }
            reader.Close();
            return result;
        }
    }
}
