using DataBase;
using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MFCLibrary.DataBase.SqlActions.ServiceSqlActions
{
    internal static class SqlDeleteService
    {
        internal static void DeleteService(MFCDataBase db, int DeleteId)
        {
            db.command = new SQLiteCommand($"DELETE FROM {db.ServiceTableName} WHERE id={DeleteId}", db.connection);
            db.command.ExecuteNonQuery();
        }
    }
}
