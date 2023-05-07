using DataBase;
using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MFCLibrary.DataBase.SqlActions.ServiceSqlActions
{
    internal static class SqlTakeValueService
    {
        internal static string TakeValueService(MFCDataBase db, string row, string checkRow, object checkValue)
        {
            string result = "";

            db.command = new SQLiteCommand($"SELECT {row} FROM {db.ServiceTableName} WHERE {checkRow}=\"{checkValue}\"", db.connection);
            SQLiteDataReader reader = db.command.ExecuteReader();
            while (reader.Read())
            {
                result = Convert.ToString(reader.GetValue(0));
            }
            reader.Close();
            return result;
        }
    }
}
