using DataBase;
using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MFCLibrary.DataBase.SqlActions.EmployeeSqlActions
{
    internal static class SqlTakeValueEmployee
    {
        internal static string TakeValueEmployee(MFCDataBase db, string row, string checkRow, object checkValue)
        {
            string result = "";

            db.command = new SQLiteCommand($"SELECT {row} FROM {db.EmployeeTableName} WHERE {checkRow}=\"{checkValue}\"", db.connection);
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
