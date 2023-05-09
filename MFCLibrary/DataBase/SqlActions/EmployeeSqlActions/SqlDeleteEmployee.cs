using DataBase;
using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MFCLibrary.DataBase.SqlActions.EmployeeSqlActions
{
    internal class SqlDeleteEmployee
    {
        internal static void DeleteEmployee(MFCDataBase db, int DeleteId)
        {
            db.command = new SQLiteCommand($"DELETE FROM {db.EmployeeTableName} WHERE id={DeleteId}", db.connection);
            db.command.ExecuteNonQuery();
        }
    }
}
