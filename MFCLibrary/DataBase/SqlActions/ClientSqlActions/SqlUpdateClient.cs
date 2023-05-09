using DataBase;
using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MFCLibrary.DataBase.SqlActions.ClientSqlActions
{
    internal static class SqlUpdateClient
    {
        internal static void UpdateClient(MFCDataBase db, string updateRow, object newValue, int id)
        {
            db.command = new SQLiteCommand($"UPDATE {db.ClientTableName} SET {updateRow}=\"{newValue}\" WHERE id={id}", db.connection);
            db.command.ExecuteNonQuery();
        }
    }
}
