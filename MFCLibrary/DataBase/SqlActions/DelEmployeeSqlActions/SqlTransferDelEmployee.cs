using DataBase;
using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MFCLibrary.DataBase.SqlActions.DelEmployeeSqlActions
{
    internal static class SqlTransferDelEmployee
    {
        internal static void TransferDelEmployee(MFCDataBase db, int id)
        {
            db.command = new SQLiteCommand($"INSERT INTO DelEmployee SELECT id, fullnameEmployee, birthday, windowNumber FROM Employee WHERE id={id}", db.connection);
            db.command.ExecuteNonQuery();
        }
    }
}
